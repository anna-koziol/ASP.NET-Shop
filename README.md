# ASP.NET-Shop
Sklep napisany w ASP.NET z funkcjonalnościami: rejestracja, mailing, logowanie, panel admina oraz bazą danych MySQL

## Screen

![GitHub Logo](./renee.jpg)

## Funkconalności:
- sprawdzanie czy nick wolny
- dodawanie zdjęć do bazy danego usera
- walidacja maila
- walidacja złożoności hasła
- sprawdzanie czy nick jest w bazie
- wykropkowane  hasło
- funkcje  haszujące hasło, dodanie  hasza do bazy
- wysyłanie maila po rejestracji z kodem rabatowym i  podziękowaniami 

### LOGOWANIE
- logowanie ze stworzeniem  sesji
- sprawdzanie czy  hasło jest poprawne
- sprawdzanie czy nick istnieje w bazie
- wykropkowane  hasło
- odhaszowanie hasła z bazy w celu sprawdzenia poprawności

### PANEL ADMINA
1)	Dodawanie:
  -	dodawanie do bazy itemów, zdjęć
  -	dodanie do  pól cena, obcas typ numer aby uniknąć błędów zapisu do bazy
  -	zabezpieczenie sekcją, przed wejściem na stronę
2)	Edycja
  -	Wyświetlanie wszystkich produktów ze sklepu (nazwa, rodzaj, cena)
  -	Własny dynamiczny buton z funkcją onClick
  -	Automatyczne wpisanie poprzednich danych produktu w polu edycji
  -	Aktualizacja w bazie danych
  -	Możliwość update zdjęcia produktu i pozostałych danych
  -	zabezpieczenie sekcją, przed edycją
3)	Usuwanie
  -	Usuwanie itemu po id z bazy
  -	Zabezpieczenie sekcją

### BAZA
- relacje w bazie
- 4 tabele

### OGÓLNE
- podpięcie czcionek
- podpięcie FontAsome

### STRONA GŁÓWNA
- lista wszystkich elementów z bazy wraz ze zdjęciem, dynamicznym przyciskiem (ikoną) z atrybutami z bazy
- ikona konta w głównym banerze -  sprawdzam czy sekcja logowania istnieje (jeśli tak to szczegóły profilu:  zdjęcie, nick. Jeśli nie to przyciski do logowania/rejestracji) 
- sortowanie po kategorii poprzez RadioButtonList
- po kliku w przycisk produktu wyświetlenie wszystkich szczegółów dotyczących produktów, wraz z buttonem „KUP” (sprawdza czy jest sesja zalogowania, jeśli tak dodaje do tabeli ‘orders’)
- stworzenie DropDownList z dynamicznie tworzoną listą rozmiarów z bazy
- stworzenie linkbuttona  w panelu szczegółów produktu, bo jego kliknięciu powrót na  stronę główną
- dodanie alertu przy próbie dodania do koszyka przedmiotu przez kogoś niezalogowanego
- alert dot. pomyślnego dodania do koszyka
- wyświetlenie listy produktów dodanych do koszyka przez aktualnie zalogowanego usera
- możliwość usuwania z koszyka
- liczenie sumy do zapłaty wraz z dostawą
- uwzględnianie kuponów do zapłaty
- zamawianie produktów, wysłanie maila z potwierdzeniem zakupu (wpisanie adresu wysyłki oraz wybór sposobu płatności)
- dodanie do bazy opłaconych zamówień
- admin może edytować status zamówienia oraz usuwać je z bazy
- wysyłanie maila po zmianie statusu
