//Funkcja wywoływana przy ładowaniu strony.
window.addEventListener("load", function(){

	// Jeśli przeglądraka to Edge.
	if(window.navigator.userAgent.indexOf("Edge") > -1 )
	{
		//Obejście na autoplay muzyki w Edgu.
		$('#musicBackground').trigger("play");
		//Obejście na ustawienie custmowego kursora w Edgu.
		//Wyłączamy kursor dla wszystkich elementów.
		$('*').css("cursor", "none");
		document.body.style.cursor = 'none';
		//Ładujemy swój kursor za pomocą niżej zaimportowanej bibliteki CursorJS.
		CursorJS.enable('Images/cursor.cur');
		CursorJS.addEl(document.body);
	}

	// Jeśli przeglądraka to Mozilla.
	else if(typeof InstallTrigger !== 'undefined')
	{
		//Obejście na autoplay muzyki w Mozilli.
		//UWAGA: Jeśli autoplay dodatkowo zablokowany w ustawieniach
		//to muzyka i tak się nie włączy.
		$('#musicBackground').trigger("play");
		$('#musicBackground').trigger("stop");
		$('#musicBackground').trigger("play");
	}

	//Animacja napisu 'clickToStart' w index.html.
	var nodes = document.querySelectorAll("#clickToStart");
	//Szukamy wszystkich liter w elemencie #clickToStart.
	for(var i=0; i<nodes.length; i++){
		//Przepisujemy litery do nowej zmiennej.
    var words = nodes[i].innerText;
		//Każdy element potrzebuje zmiennej hmtl, do której będzie wpisywany tekst.
    var html = "";
		//Pętla uzupełniająca litery.
    for(var i2=0; i2<words.length; i2++){
			//Jeśli spacja.
    	if(words[i2] == " "){
				//Dodaj bez kontenera.
          html += words[i2];
      }
    	else{
				//Dopisz kontener z literą do htmla.
        html += "<span>"+words[i2]+"</span>"
      }
    }
		//Nadpisz tekst w napisie 'clickToStart'.
    nodes[i].innerHTML = html;
	}
});

// Funkcje na klik.

//Funkcja wykonywana po naciśnięciu na zdjęcie głośnika w index.html.
$(function() {
  $('#soundOnOff').on('click', function()
  {
		//Jeśli obrazek głośnika.
    if($(this).css('background-image').indexOf('sound.png') >= 0)
    {
			//Zmień obrazek na przekreślony głośnik.
      $(this).css('background-image', "url('Images/mute.png')");
			//Zatrzymaj muzykę.
      $('#musicBackground').trigger("pause");
			//Poniższy element służy jako obejście autoplayu muzyki na Edgu.
			if($('#autoplayWorkaround'))
			{
				//Usuwamy element.
				$('#autoplayWorkaround').remove();
			}
    }
		//Jeśli obrazek przekreślonego głośnika.
    else if ($(this).css('background-image').indexOf('Images/sound.png'))
    {
			//Zmień obrazek na głośik.
      $(this).css('background-image', "url('Images/sound.png')");
			//Włącz muzykę.
      $('#musicBackground').trigger("play");
    }
  });
});

//Funkcja wywoływana po kliknięciu napisu #clickToStart.
$(function() {$('#clickToStart').on('click', function()
  {
		//Przechodzimy do strony choiceMenu.html.
		window.location.assign("ChoiceMenu.html");
	});
});

//Funkcja wywoływana po kliknięciu obrazka po lewej w choiceMenu.html.
$(function() {$('#show1').on('click', function()
  {
		//Przechodzimy do strony characters.html.
		window.location.assign("characters.html");
	});
});

//Funkcja wywoływana po kliknięciu środkowego obrazka w choiceMenu.html.
$(function() {$('#show2').on('click', function()
  {
		//Przechodzimy do strony images.html.
		window.location.assign("images.html");
	});
});

//Funkcja wywoływana po kliknięciu obrazka po prawej w choiceMenu.html.
$(function() {$('#show3').on('click', function()
  {
		//Przechodzimy do strony game.html.
		window.location.assign("game.html");
	});
});

//Funkcja wywoływana po kliknięciu przycisku restart w game.html.
$(function() {$('#restart').on('click', function()
  {
		location.reload();
	});
});

//Funkcja wywoływana po kliknięciu przycisku powrotu do choiceMenu.html.
$(function() {$('.button').on('click', function()
  {
		//Przechodzimy do strony choiceMenu.html.
		window.location.assign("choiceMenu.html");
	});
});

//JS do game.html.

//Funkcja mieszająca listę elementów.
function shuffle(a) {
    var j, x, i;
    for (i = a.length - 1; i > 0; i--) {
        j = Math.floor(Math.random() * (i + 1));
        x = a[i];
        a[i] = a[j];
        a[j] = x;
    }
    return a;
}

var path = window.location.pathname;
//Nazwa strony na której jesteśmy.
var page = path.split("/").pop();

//Jeśli strona to game.html utwórz zmienne.
if (page == "game.html"){

	//Tworzymy listę ze zdjęciami do gry.
	var cards = shuffle(["card1.png", "card2.png", "card3.png", "card4.png",
	"card5.png", "card6.png", "card7.png", "card8.png", "card9.png",
	"card10.png", "card1.png", "card2.png", "card3.png", "card4.png",
	"card5.png", "card6.png", "card7.png","card8.png",
	"card9.png", "card10.png"]);

	//Torzymy 20 zmiennych odwołujących się do kolejnych kart.
	var c0 = document.getElementById('c0');
	var c1 = document.getElementById('c1');
	var c2 = document.getElementById('c2');
	var c3 = document.getElementById('c3');

	var c4 = document.getElementById('c4');
	var c5 = document.getElementById('c5');
	var c6 = document.getElementById('c6');
	var c7 = document.getElementById('c7');

	var c8 = document.getElementById('c8');
	var c9 = document.getElementById('c9');
	var c10 = document.getElementById('c10');
	var c11 = document.getElementById('c11');

	var c12 = document.getElementById('c12');
	var c13 = document.getElementById('c13');
	var c14 = document.getElementById('c14');
	var c15 = document.getElementById('c15');

	//Ładujemy zdarzenie na klik do każdej karty.
	c0.addEventListener("click", function() { revealCard(0); });
	c1.addEventListener("click", function() { revealCard(1); });
	c2.addEventListener("click", function() { revealCard(2); });
	c3.addEventListener("click", function() { revealCard(3); });

	c4.addEventListener("click", function() { revealCard(4); });
	c5.addEventListener("click", function() { revealCard(5); });
	c6.addEventListener("click", function() { revealCard(6); });
	c7.addEventListener("click", function() { revealCard(7); });

	c8.addEventListener("click", function() { revealCard(8); });
	c9.addEventListener("click", function() { revealCard(9); });
	c10.addEventListener("click", function() { revealCard(10); });
	c11.addEventListener("click", function() { revealCard(11); });

	c12.addEventListener("click", function() { revealCard(12); });
	c13.addEventListener("click", function() { revealCard(13); });
	c14.addEventListener("click", function() { revealCard(14); });
	c15.addEventListener("click", function() { revealCard(15); });

	c12.addEventListener("click", function() { revealCard(12); });
	c13.addEventListener("click", function() { revealCard(13); });
	c14.addEventListener("click", function() { revealCard(14); });
	c15.addEventListener("click", function() { revealCard(15); });

	c16.addEventListener("click", function() { revealCard(16); });
	c17.addEventListener("click", function() { revealCard(17); });
	c18.addEventListener("click", function() { revealCard(18); });
	c19.addEventListener("click", function() { revealCard(19); });

	//Zmienna inforumjąca, czy odkrywamy pierwszą, czy drugą kartę.
	var oneVisible = false;
	//Licznik ruchów.
	var turnCounter = 0;
	//Numer pierwszej odsłoniętej karty.
	var visible_nr;
	//Zmienna blokująca ruch, gdy dwie karty odkryte.
	var lock = false;
	//Ilośc par do znalezienia.
	var pairsLeft = 10;
}

//Funkcja odpowiadająca za odkyrcie karty.
function revealCard(nr)
{
	//Widoczność naciskanej karty.
	var opacityValue = $('#c'+nr).css('opacity');

	//Jeśli możemy wykonać akcję, a karta którą naciskamy jest widoczna.
	if (opacityValue != 0 && lock == false)
	{
		//Zablokuj
		lock = true;
		//Załaduj obraz karty.
		var obraz = "url(Images/" + cards[nr] + ")";
		$('#c'+nr).css('background-image', obraz);
		//Dodaj do karty parametry klasy cardA.
		$('#c'+nr).addClass('cardA');
		//Usuń z karty elementy klasy card.
		$('#c'+nr).removeClass('card');

		//Jeśli odkyrwamy pierwszą kartę.
		if(oneVisible == false)
		{

			oneVisible = true;
			//Zapisujemy numer odsłoniętej karty.
			visible_nr = nr;
			//Odblokowujemy ruch.
			lock = false;
		}
		//Jeśli odkrywamy drugą kartę.
		else
		{
			//Jeśli druga karta nie jest jednocześnie pierwszą kartą (podwójny klik).
			if(visible_nr != nr)
				{
					//Jeśli ścieżki do zdjęć kart takie same.
					if(cards[visible_nr] == cards[nr])
					{
						//Mamy parę, więc usuwamy ją z planszy.
						setTimeout(function(){ hide2Cards(nr, visible_nr)}, 750);
						}
					else
						{
						//Gracz spudłował, więc przywracamy karty.
						setTimeout(function(){ restore2Cards(nr, visible_nr)}, 750);
						}
				//Naliczamy ruch.
				turnCounter++;
				//Aktualizujemy ilość ruchów w pliku game.html.
				$('.score').html('Turn counter: '+turnCounter);
				//Resetujemy zmienną oneVisible.
				oneVisible = false;
				}
			//Jeśli podwójny klik na jedną kartę.
			else
				{
					//Odblokuj możliwość ruchu.
					lock = false;
				}
		}
	}
}

//Funckcja odpowiedzialna za usunięcie kart z planszy.
function hide2Cards(nr1, nr2)
{
	//Ładujemy dźwięk.
	var audio = new Audio('sounds/correct.wav');
	audio.play();

	//Zmieniamy karty na całkowicie przezroczyste.
	$('#c'+nr1).css('opacity', '0');
	$('#c'+nr2).css('opacity', '0');

	//Zmniejszamy licznik pozostałych par.
	pairsLeft--;

	//Jeśli nie pozostała żadna paar.
	if(pairsLeft == 0)
	{
		//Ładujemy dźwięk wygranej.
		var audio = new Audio('sounds/win.mp3');
		audio.play();

		//Wyświetlamy napis.
		$('.board').html('<h1 id="winText">You win!<br>Done in '+
		turnCounter+' turns</h1>');
		$('#restart').css('font-size', '60px');

		//Ustawiamy rozmiar napisu i przycisku w zależności od rozmiaru okna.
		if($(window).width() <= 1100)
		{
			$("#restart").css('left', Math.round( ($(window).width() -
			$('#restart').width() - 50)/2)+'px');
			$('.board').css('width', '420px');
		}
		else
		{
			$('#restart').css('left', '11%');
			$('#restart').css('transform', 'translateY(5rem)');
			$('.board').css('width', '600px');
		}

		//Zmieniamy przycisk restartu na widoczy.
		$('#restart').css('visibility', 'visible');

	}
	//Odblokowujemy ruch.
	lock = false;
}

//Funkcja przywracająca karty na planszę.
function restore2Cards(nr1, nr2)
{
	//Ładujemy dźwięk.
	var audio = new Audio('sounds/wrong.wav');
	audio.play();

	//Odwracamy karty i wracamy z klasy cardA do klasy Card.
	$('#c'+nr1).css('background-image', 'url(Images/karta.png)');
	$('#c'+nr1).addClass('card');
	$('#c'+nr1).removeClass('cardA');
	$('#c'+nr2).css('background-image', 'url(Images/karta.png)');
	$('#c'+nr2).addClass('card');
	$('#c'+nr2).removeClass('cardA');

	//Odblokowujemy ruch.
	lock = false;
}

//JS do images.html.

//wartość zawierająca informację o wielkości strony (EXTRASMALL/SMALL/BIG).
var sizeName;
//Wartość przez którą mnożyny rozmiar zdjęć.
var resizeValue;

//Jeśli obecna strona to images.html.
if (page == "images.html"){
	//Wykonaj, gdy strona bezpieczna do manipulowania.
	$(document).ready(function() {
		if($(window).width() <= 700)
		{
			//Zapisujemy iformację o aktualnej wielkości strony.
			sizeName = "startEXTRASMALL";
			resizeValue = 0.25;
		}
		else if($(window).width() <= 1100)
		{
			//Zapisujemy iformację o aktualnej wielkości strony.
			sizeName = "startSMALL";
			resizeValue = 0.5;
		}
		else
		{
			//Zapisujemy iformację o aktualnej wielkości strony.
			sizeName = "startBIG";
			resizeValue = 1;
		}

		//Funkcja zmieniająca rozmiar zdjęć w zależności od rozmiaru strony.
    function changeSize() {
			//Szerokość strony.
      var windowSize = $(window).width();

			//Jeśli strona EXTRASMALL od początku lub rozmiar strony zmieniony
			//do EXTRASMALL, a zmianny jeszcze nie wprowadzone.
			if ((windowSize <= 700 && sizeName != "EXTRASMALL")
			|| sizeName == "startEXTRASMALL") {

				//Jeśli poprzedni rozmiar to BIG.
				if(sizeName == "BIG"){
					resizeValue = 0.25;
				}
				//Jeśli poprzedni rozmiar to SMALL.
				if(sizeName == "SMALL"){
					resizeValue = 0.5;
				}

					//Zmieniamy wielkość zdjęć.
					$(".shadow").css('width', Math.round( $('.shadow').width()
					*resizeValue)+'px');

					$(".shadow").css('height', Math.round( $('.shadow').height()
					*resizeValue)+'px');

					//Zmieniamy wysunięcie zdjęć.
					for(var i = 1; i < 13; i++){
						$('.content-carrousel figure:nth-child(' + i + ')').css('transform',
						 'rotateY(' + (30*i - 30) + 'deg) translateZ(140px)');
					}
					//Zmiana marginesu.
					$(".shadow").css('margin-right',  50 + 'vw');


					sizeName = "EXTRASMALL";
					resizeValue = 2;
			}

        else if ((windowSize <= 1100 &&  windowSize > 700 &&
					sizeName != 'SMALL') || sizeName == "startSMALL") {


					//Zmieniamy wielkość zdjęć.
					$(".shadow").css('width', Math.round( $('.shadow').width()
					*resizeValue)+'px');
					$(".shadow").css('height', Math.round( $('.shadow').height()
					*resizeValue)+'px');

					//Zmieniamy wysunięcie zdjęć.
					for(var i = 1; i < 13; i++){
						$('.content-carrousel figure:nth-child(' + i + ')').css('transform',
						 'rotateY(' + (30*i - 30) + 'deg) translateZ(280px)');
					}

					sizeName = 'SMALL';
			}

        else if ((windowSize > 1100 && sizeName != 'BIG')
				|| sizeName == 'startBIG'){

					//Jeśli poprzedni rozmiar to EXTRASMALL.
					if(sizeName == "EXTRASMALL"){
						resizeValue = 4;
					}

					//Jeśli poprzedni rozmiar to SMALL.
					else if(sizeName == "SMALL"){
						resizeValue = 2;
					}

					//Zmieniamy wielkość zdjęć.
					$(".shadow").css('width', Math.round( $('.shadow').width()
					*resizeValue)+'px');

					$(".shadow").css('height', Math.round( $('.shadow').height()
					*resizeValue)+'px');

					//Zmieniamy wysunięcie zdjęć.
					for(var i = 1; i < 13; i++){
						$('.content-carrousel figure:nth-child(' + i + ')').css('transform',
						 'rotateY(' + (30*i - 30) + 'deg) translateZ(530px)');
					}

					sizeName = 'BIG';
					resizeValue = 0.5;
        }
    }

    //Wykonaj przy ładowaniu.
    changeSize();
    //Wykonaj, gdy rozmiar okna zmieniany.
    $(window).resize(changeSize);
})
}

//Funckcja zmienia rozmiar zdjęć, gdy najedziemy na nie kursorem.
function changeSizeOnHover(number, rotate){
	//Funkcja wywoływanam gdy najedziemy kursorem na któreś ze zdjęć.
	$(function() {
	  $('#fig'+number).hover(function() {
			if($(window).width() > 1100){
				//Przybliżamy zdjęcie.
		    $('#fig'+number).css('transform',
				'rotateY(' + rotate + 'deg) translateZ(580px)');
			}

			else if($(window).width() < 1100 && $(window).width() > 700){
				//Przybliżamy zdjęcie.
				$('#fig'+number).css('transform',
				'rotateY(' + rotate + 'deg) translateZ(340px)');

				//Powiększamy zdjęcie.
				$('#fig'+number).css('width',
				Math.round( $('#fig'+number).width()*2)+'px');
				$('#fig'+number).css('height',
				Math.round( $('#fig'+number).height()*2)+'px');
			}

			else{
				//Przybliżamy zdjęcie.
				$('#fig'+number).css('transform',
				'rotateY(' + rotate + 'deg) translateZ(200px)');
				//Powiększamy zdjęcie.
				$('#fig'+number).css('width',
				Math.round( $('#fig'+number).width()*3)+'px');
				$('#fig'+number).css('height',
				Math.round( $('#fig'+number).height()*3)+'px');
			}

			//Funkcja odwracająca zmiany jakie powstały przy hoverze.
	  }, function() {
			if($(window).width() > 1100){
				//Oddalamy zdjęcie.
		    $('#fig'+number).css('transform',
				'rotateY(' + rotate + 'deg) translateZ(530px)');
			}
			else if($(window).width() < 1100 && $(window).width() > 700){
				//Oddalamy zdjęcie.
				$('#fig'+number).css('transform',
				'rotateY(' + rotate + 'deg) translateZ(280px)');

				//Pomniejszamy zdjęcie.
				$('#fig'+number).css('width',
				Math.round( $('#fig'+number).width()/2)+'px');
				$('#fig'+number).css('height',
				Math.round( $('#fig'+number).height()/2)+'px');
			}
			else{
				//Oddalamy zdjęcie.
				$('#fig'+number).css('transform',
				'rotateY(' + rotate + 'deg) translateZ(140px)');

				//Pomniejszamy zdjęcie.
				$('#fig'+number).css('width',
				Math.round( $('#fig'+number).width()/3)+'px');
				$('#fig'+number).css('height',
				Math.round( $('#fig'+number).height()/3)+'px');
			}
	  });
	});
	}

	//Wywołujemy funkcję na wszystkich elementach.
	for(var i = 1; i < 13; i++){
		changeSizeOnHover(i, 30*i -30);
}

//JS do różnych plików.

//Jeśli jedna ze stron aktualnie załadowana.
if (page == "game.html" || page == "images.html" || page == "characters.html"){
	//Wykonaj, gdy strona bezpieczna do manipulowania.
	$(document).ready(function() {
		//Funckcja sprawdzająca szerokość strony.
		function checkWidth() {
			//Szerokość strony.
      var windowSize = $(window).width();

			//Jeśli szerokość strony mniejsza niż 1100.
			if (windowSize <= 1100) {
				//Zmień położenie przycisku tak, aby był w centrum pod tytułem.
				$(".noBootstrapButton").css('left', Math.round( ($(window).width() -
				$('.noBootstrapButton').width())/2)+'px');

				//Zmień położenie przycisku tak, aby było pod tytułem.
				$("#restart").css('left', Math.round( ($(window).width() -
				$('#restart').width() - 50)/2)+'px');

				//Zmiana rozmiaru kart i tablicy tak żeby mieściły się w oknie.
				$('.card').css('width', '60px');
				$('.card').css('height', '60px');
				$('.cardA').css('width', '60px');
				$('.cardA').css('height', '60px');
				$('.board').css('width', '420px');
			}
			//W przeciwnym wypaku równaj przycisk do lewej.
			else{
        $('.noBootstrapButton').css('left', '0%');
				$('.noBootstrapButton').css('right', '25%');

				//Zmień położenie przycisku tak, aby było pod tytułem.
				$('#restart').css('left', '41%');
				$('#restart').css('transform', 'translateY(5rem)');
        	}

			if(windowSize >= 800)
			{
				$('.card').css('width', '90px');
				$('.card').css('height', '90px');
				$('.cardA').css('width', '90px');
				$('.cardA').css('height', '90px');
				$('.board').css('width', '600px');
			}
				}
		//Wykonaj przy ładowaniu.
    checkWidth();
    //Wykonaj, gdy rozmiar okna zmieniany.
    $(window).resize(checkWidth);
})
}

//BiBliteka CursorJS. Pozwala na zmianę kursora na customowy w Edgu (NIE MOJA).
//Źródło: https://jsfiddle.net/gfLsgjp4/3/

//Tworzymy obiekt CursorJS.
var CursorJS = {
	//Inicjujemy zdjęcie.
	img: new Image(),
	//Inicjujemy listę.
	els: [],
	//Położenie względem kursora.
	mouseOffset: {
		x: 0,
		y: 0
	},
	addedImg: false,
	//Sprawdzamy czy Edge.
	checkForIE: function() {
		return (/MSIE/i.test(navigator.userAgent)
				|| /rv:11.0/i.test(navigator.userAgent));
	},
	//Ustawiamy rozmiary oraz wyświetlanie zdjęcia.
	setDisplay: function() {
		this.img.style.width = '50px';
		this.img.style.display =
			this.els.indexOf(true) > -1 ? null : 'none';
	},
	//Sprawdzamy współrzędne kursora.
	getMouseCoords: function(e) {
		var mx = 0, my = 0;
		if (this.checkForIE())
			mx = event.clientX + document.body.scrollLeft,
			my = event.clientY + document.body.scrollTop;
		else
			mx = e.pageX,my = e.pageY;
		if (mx < 0) mx = 0;
		if (my < 0) my = 0;
		return [mx, my];
	},

	//Ustawiamy położenie zdjęcia względem kursora,
	//gdy jest na ustawionym elemencie.
	mouseOver: function(e, id) {
		this.els[id] = true;
		this.setDisplay();
		var coords = this.getMouseCoords(e);
		this.img.style.left =
			(coords[0]+this.mouseOffset.x) + 'px';
		this.img.style.top =
			(coords[1]+this.mouseOffset.y) + 'px';
	},

	//Wyłączamy kursor, gdy kursor opuszcza element, na którym został ustawiony.
	mouseOut: function(e, id) {
		this.els[id] = false;
		this.setDisplay();
	},

	//Ustawiamy poruszanie się zdjęcia nałożonego na kursor.
	mouseMove: function(e) {
		var coords = this.getMouseCoords(e);
		this.img.style.left =
			(coords[0]+this.mouseOffset.x) + 'px';
		this.img.style.top =
			(coords[1]+this.mouseOffset.y) + 'px';
	},

	//Tworzymy metodę odpowiedzialną za łączenie elementu z metodą kursora.
	addEvent: function(el, name, func, bool) {
		if (el == null || typeof name != 'string'
				|| typeof func != 'function'
				|| typeof bool != 'boolean')
			return;
		if (el.addEventListener)
			el.addEventListener(name, func, false);
		else if (el.attachEvent)
			el.attachEvent('on' + name, func);
		else
			el['on' + name] = func;
	},

	//Łączymy 3 metody kursora z elementem na stronie.
	addEl: function(el) {
		var evts = ['over','out','move'],
			id = this.els.length;
		this.els.push(false);
		this.el = el;
		this.addEvent(el, 'mouseover', function(e) {
			this.mouseOver(e, id) }.bind(this), false);
		this.addEvent(el, 'mouseout', function(e) {
			this.mouseOut(e, id) }.bind(this), false);
		this.addEvent(el, 'mousemove', function(e) {
			this.mouseMove(e) }.bind(this), false);
		if (typeof el['style'] != 'undefined')
			el.style.cursor = 'none';
	},
	//Usuwamy defaultowy kursor i odblokowujemy nowy.
	enable: function(src) {
		this.img.src = src;
		this.img.style.display = 'none';
		this.img.style.position = 'absolute';
		this.addEvent(this.img, 'mousemove', function(e) {
			this.mouseMove(e) }.bind(this), false);
		if (!this.addedImg)
			document.body.appendChild(this.img),
			this.addedImg = true;
	}
}
