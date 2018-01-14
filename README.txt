	
	OCR - Office of Cells Romania

	Aplicatie a fost dezvoltata de Dulgheriu Denis si Chrila Stefan , anul III , grupa E213-C si are ca si tema calcularea pontajului angajatilor unei companii.
Ca un upgrade adus temei propuse am implementat un sistem de recunoastere a codului asignat fiecarui angajat folosind Optical Character Recognition . Aplicatia nu doar calculeaza pontajul angajatilor ci calculeaza efectiv orele lucrate de acestia zilnic , in mod real , natural .	
	
Aplicatia ofera un mediu usor de folosit de catre utilizatorul obisnuit si unul accesibil administratorului bazei de date impartind interfata propusa in doua zone clar delimitate. Zona Angajat si Zona Admin .
	
	Zona Angajat :
		-> Intrare 
		-> Iesire	
Aceste doua butoane "logeaza" si "delogheaza" angajatul inregistrandul automat in isoricul intrari-iesiri . Desigur , pe cele doua butoane au fost impuse restrictii ca : 
			-> a nu se loga daca nu a fost delogat
			-> a nu se deloga daca nu a fost logat in prealabil
			-> a se verifica disponibilitatea angajatului referitor la concediu
Pe baza timpului in care angajatul este logat pe platforma , a programului de baza a anagajatului si a functie detinute , acestuia i se calculeaza salariul individual .

Desi butonul Statistici face parte din zona Administrarii datelor , acesta poate fi accesat si de catre un simplu angajat fiind disponibile diverse informatii ca :
	-> sa se afiseze orele muncite de catre un anume angajat ( metoda ce interogheaza baza de date pentru intoarce numarul de ore muncite in aceasta sesiune de lucru de catre un anagajat ) ;
	-> sa se afiseze angajatii folosind ca si criteriu functia acestora ;
	-> sa se verifice disponibilitatea unui angajat in sesiunea curenta ;
	-> sa se afiseze o lista a tuturor angajatilor companiei in functie de vechime ;
	-> sa se calculeze si sa se  pe baza pontajului individual din sesiunea curenta , salariul fiecarui anagajat ;
	-> sa se afiseze topul celor mai buni angajati ai firmei pe baza functie detinute de acestia ;
	-> sa se afiseze un raport cu intrarile iesirile tuturor angajatilor ;
	
	
	Zona Admin :
	
Pentru a spori securitatea si integritatea bazei de date utilizatorul ce incearca accesarea acestei zone va trebui sa introduca o parola de verificare.
	Dupa ce verificarea s-a efectuat cu succes , utilizatorul are acces la butoanele :
		-> Angajat nou ;
		-> Concediu angajat ;
		-> Avansare ;
		-> Efectuare bilant ;
		-> Stergere anagajat .		
Toate aceste facilitati opereaza direct pe baza de date , oferind utilizatorului optiuni ca : 
-> a introduce si a sterge un angajat ; 
-> a oferi unui angajat o perioada limitat de concediu ;
-> a avansa in functie un angajat . 
De asemenea se poate accesa raportul cu salariile lunare ale angajatiilor .

	Pentru implementarea tuturor facilitatilor aplicatiei s-au creat : 
		-> o baza de date locala ;
		-> 7 tabele relationate intre ele prin chei primare si straine : 
				- Angajat ; 
				- Concedii ; 
				- Functii ; 
				- Intrari ; 
				- Master ; 
				- Salarii ; 
				- Sporuri .
		-> 4 view-uri :
				- ListaVechimeAngajat ;
				- VedereSalariiNet ;
				- TopAngajati ;
				- VedereSalarii .
		-> 2 proceduri stocate : 
				- AngajatiDupaFunctii - cu parametrul @functie ;
				- VerificaConcediuAngajat - cu parametrul @nume_angajat.
		-> o tranzactie .
		
	Limbajul de programare folosit este C# imbinat , fireste , cu limbajul SQL . Pentru buna functionare a aplicatie sunt necesare o camera web si suportul pentru cardurile cartonate ale utilizatorilor .
