using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using zadanie.Api.Models;

namespace zadanie.Api.Controllers
{
    [Route("api/forum")]
    [ApiController]
    public class MedievalStudentsController : ControllerBase
    {
        private static Dictionary<string, NewCharacter> _characters;
        private static Dictionary<string, Issue> _issues;
        private static readonly List<string> _index;

        static MedievalStudentsController()
        {
            _characters = new Dictionary<string, NewCharacter>();
            _index = new List<string> { "characters", "issues"};
            _issues = new Dictionary<string, Issue>();
        }

        /// <summary>
        /// Get list of subsites.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_index);
        }

        /// <summary>
        /// Get propositions of new characters sent by users.
        /// </summary>
        /// <returns></returns>
        [HttpGet("characters")]
        public IActionResult CharactersGet()
        {

            List<dynamic> characterList = new List<dynamic>();
            foreach (NewCharacter character in _characters.Values)
            {
                Character fields = new Character()
                {
                    Id = character.Id,
                    CharacterName = character.PostedCharacter.CharacterName,
                    CharacterClass = character.PostedCharacter.CharacterClass,
                    CharacterSex = character.PostedCharacter.CharacterSex,
                    CharacterHistory = character.PostedCharacter.CharacterHistory,
                };
                characterList.Add(fields);
            }

            return Ok(characterList);
        }

        /// <summary>
        /// Post proposition of the new character. Maybe your character will be next in MedievalStudents game.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost("characters")]
        public IActionResult CharactersPost([FromBody] NewCharacter character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var id = Guid.NewGuid().ToString();

            character.Id = id;
            _characters.Add(id, character);

            return Ok();
        }

        /// <summary>
        /// Delete character proposition by id.
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        [HttpDelete("characters/{characterId}")]
        public IActionResult CharacterDelete(string characterId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _characters.Remove(characterId);
            return NoContent();
        }

        /// <summary>
        /// Get data of user who created character propostion.
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        [HttpGet("characters/{characterId}")]
        public IActionResult CharacterGet(string characterId)
        {
            if (_characters.Keys.Contains(characterId))
            {
                var character = _characters[characterId];
                UserClass user = new UserClass()
                {
                    FirstName = character.User.FirstName,
                    LastName = character.User.LastName,
                    Email = character.User.Email,
                };
                return Ok(user);
            }
            return NotFound();
        }

        /// <summary>
        /// Change posted data about character by id.
        /// </summary>
        /// <param name="characterId"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPatch("characters/{characterId}")]
        public IActionResult CharacterPatch(string characterId, NewCharacter character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var searchedResult = _characters.TryGetValue(characterId, out NewCharacter existingCharacter);

            if (!searchedResult)
            {
                return NotFound();
            }

            existingCharacter.User = character.User;
            existingCharacter.PostedCharacter = character.PostedCharacter;
            existingCharacter.ImageData = character.ImageData;
            return NoContent();
        }

        /// <summary>
        /// Get character image (if posted).
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        [HttpGet("characters/{characterId}/image")]
        public IActionResult CharactersImageGet(string characterId)
        {
            var searchedResult = _characters.TryGetValue(characterId, out NewCharacter character);

            if (!searchedResult)
            {
                return BadRequest();
            }
            if (character.ImageData != Array.Empty<byte>() && character.ImageData != null)
            {
                //Depending on if you want the byte array or a memory stream, you can use the below. 
                //THIS IS NO LONGER NEEDED AS OUR MODEL NOW HAS A BYTE ARRAY
                //var imageDataByteArray = Convert.FromBase64String(model.ImageData);

                //When creating a stream, you need to reset the position, without it you will see that you always write files with a 0 byte length. 
                var imageDataStream = new MemoryStream(character.ImageData)
                {
                    Position = 0
                };

                //Go and do something with the actual data.
                //_customerImageService.Upload([...])

                //For the purpose of the demo, we return a file so we can ensure it was uploaded correctly. 
                //But otherwise you can just return a 204 etc. 
                return File(character.ImageData, "image/png");
            }
            return NoContent();
        }

        /// <summary>
        /// Delete image of character.
        /// </summary>
        /// <param name="characterId"></param>
        /// <returns></returns>
        [HttpDelete("characters/{characterId}/image")]
        public IActionResult CharactersImageDelete(string characterId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var searchedResult = _characters.TryGetValue(characterId, out NewCharacter existingCharacter);

            if (!searchedResult)
            {
                return NotFound();
            }

            existingCharacter.ImageData = Array.Empty<byte>();
            return NoContent();
        }

        /// <summary>
        /// Get list with all topics and tags.
        /// </summary>
        /// <returns></returns>
        [HttpGet("issues")]
        public IActionResult IssuesGet()
        {

            List<dynamic> issuesList = new List<dynamic>();
            foreach (Issue issue in _issues.Values)
            {
                Topic fields = new Topic()
                {
                    Id = issue.Id,
                    TopicName = issue.TopicInfo.TopicName,
                    Tags = issue.TopicInfo.Tags
                };
                issuesList.Add(fields);
            }

            return Ok(issuesList);
        }

        /// <summary>
        /// Post new issue.
        /// </summary>
        /// <param name="issue"></param>
        /// <returns></returns>
        [HttpPost("issues")]
        public IActionResult IssuesPost(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var id = Guid.NewGuid().ToString();

            issue.Id = id;
            _issues.Add(id, issue);

            return Ok();
        }

        /// <summary>
        /// Get list of messages in topic by topic id.
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        [HttpGet("issues/{issueId}")]
        public IActionResult IssuesGet(string issueId)
        {
            if (_issues.Keys.Contains(issueId))
            {
                return Ok(_issues[issueId].ListOfMessages);
            }
            return NotFound();
        }

        /// <summary>
        /// Post message in topic.
        /// </summary>
        /// <param name="issueId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost("issues/{issueId}")]
        public IActionResult IsuesPost(string issueId, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_issues.Keys.Contains(issueId))
            {
                var id = Guid.NewGuid().ToString();

                message.Id = id;
                if (_issues[issueId].ListOfMessages == null)
                {
                    _issues[issueId].ListOfMessages = new Dictionary<string, Message>();
                }
                _issues[issueId].ListOfMessages[id] = message;

                return Ok();
            }
            return NotFound();

        }

        /// <summary>
        /// Delete whole topic by topic id.
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        [HttpDelete("issues/{issueId}")]
        public IActionResult IssueDelete(string issueId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _issues.Remove(issueId);
            return NoContent();
        }

        /// <summary>
        /// Delete message by message id.
        /// </summary>
        /// <param name="issueId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpDelete("issues/{issueId}/{messageId}")]
        public IActionResult IsuesMessagePost(string issueId, string messageId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var searchedResult = _issues.TryGetValue(issueId, out Issue existingIssue);

            if (!searchedResult)
            {
                return NotFound();
            }

            if (_issues.Keys.Contains(issueId))
            {
                if (_issues[issueId].ListOfMessages == null)
                {
                    _issues[issueId].ListOfMessages = new Dictionary<string, Message>();
                }

                _issues[issueId].ListOfMessages.Remove(messageId);
                return NoContent();
            }
            return NotFound();
            }

        /// <summary>
        /// Get message by message id.
        /// </summary>
        /// <param name="issueId"></param>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpGet("issues/{issueId}/{messageId}")]
        public IActionResult IssuesMessageGet(string issueId, string messageId)
        {
            var searchedResult = _issues.TryGetValue(issueId, out Issue existingIssue);

            if (!searchedResult)
            {
                return NotFound();
            }

            if (_issues.Keys.Contains(issueId))
            {
                if (_issues[issueId].ListOfMessages == null)
                {
                    _issues[issueId].ListOfMessages = new Dictionary<string, Message>();
                }

                if (_issues[issueId].ListOfMessages.Keys.Contains(messageId))
                {
                    return Ok(_issues[issueId].ListOfMessages[messageId].User);
                }
                return NotFound();
            }
            return NotFound();
        }
    }
}
