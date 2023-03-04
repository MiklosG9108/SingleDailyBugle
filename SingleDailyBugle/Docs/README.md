# Daily Bugle projekt

A Daily Bugle (magyarul Hírharsona néven jelenik meg) fel szeretné újítani a háttérrendszereit, és a fejlesztéssel a ti csapatotokat bízták meg.  
A feladatot kezdjétek a leírás elolvasásával és tervezéssel. Találjátok ki az alapvető adatbázis-szerkezetet és az url-eket, és aztán haladjatok az implementálással lépésenként.  
Próbáljatok minél több “leszállítható” részt megcsinálni, azaz inkább legyen meg a hét végéig több részfeladat teljesen, mint sok részfeladatnak csak mondjuk az adatbázis része.
A nem egymásra épülő részfeladatokat tetszőleges sorrendben valósíthatjátok meg, nem kell betartani a lenti sorrendet.  
Dolgozzatok pair-programmingban is!

Ne felejtsetek el gyakran commitolni, update-elni és push-olni, hogy elkerüljétek a merge conflictokat!

A feladat nyílt végű, ha esetleg minden részfeladattal készen vagytok, akkor tovább lehet bővíteni egyedi ötletek alapján.

## Általános feladatok

Minden “létrehozás” jellegű feladat esetén tárolni kell a létrehozás időpontját, amit a szerveren kell beállítani.  
Minden “módosítás” vagy “törlés” esetén tárolni kell az utolsó módosítás időpontját (csak az utolsót, és a törlés ebből a szempontból módosításnak minősül).  
Minden “törlés” esetén ne történjen valódi törlés az adatbázisból, csak státusz legyen állítva.

## Cikkek (regisztráció nélkül elérhető rész)

A rendszerben lehet cikkeket rögzíteni. Minden cikknek van azonosítója, szerzője (egyelőre String), címe, rövid szinopszisa és teljes szövege.
A cikkeket lehet listázni, ebben az esetben az ID, szerző, cím és rövid szinopszis jelenik meg egy cikkről.
Azonosító alapján el lehet kérni egy konkrét cikket, ebben az esetben az összes adatát megkapjuk, a teljes szövegével együtt és a szerző nevével  együtt.
Cikket lehet módosítani és törölni, az alap feltételekkel.

## Kommentelés (regisztráció nélkül elérhető rész)

A cikkekhez van lehetőség kommentet írni, egy kommentről eltároljuk a szerzőjét (egyelőre egy sima Stringben), a tartalmát, hogy melyik cikkhez tartozik, a létrehozás időpontját (szerveren beállítva) és egy azonosítót.
A cikkeknél listázás esetén jelenjen meg, hogy hány komment érkezett rájuk, teljes cikk megjelenítésénél pedig maguk a kommentek, időrendben csökkenő sorrendben.

## Értékelés (regisztráció nélkül elérhető rész)

Minden cikket lehet értékelni 1-től 5-ig egy egész számmal. Az értékelés nincs felhasználóhoz kötve (egyelőre), egy cikkre akármennyi értékelés érkezhet.
A cikkeknél minden helyen (teljes listázás, szerző cikkei, teljes cikk ID alapján) jelenjen meg az átlagos értékelésük két tizedesjegyre kerekítve, illetve hogy hány értékelést kaptak.

## Regisztráció

Az alkalmazásba lehet regisztrálni, ehhez meg kell adni egy emailcímet, jelszót, megjelenítendő nevet, és hogy olvasói vagy újságírói regisztrációról van szó.
Regisztrációt követően be lehet jelentkezni az emailcím-jelszó párosssal az alkalmazásba, és bizonyos funkciók csak ezután lesznek elérhetőek:
- cikk írása: csak újságírói regisztrációval, a szerző nevének megadása helyett a bejelentkezett felhasználó legyen rögzítve a cikkhez (nem csak a neve, hanem a teljes regisztrált entitás)
- komment írása: csak bejelentkezéssel lehet rögzíteni, olvasó és újságíró is rögzíthet, a szerző neve helyett a regisztrált entitás legyen rögzítve hozzá
- értékelés: csak bejelentkezéssel lehet rögzíteni, olvasó és újságíró is rögzíthet értékelést, de egy személy egy cikket csak egyszer értékelhet

## Felhasználói profil

Legyen lehetőség ID alapján elkérni egy olvasó vagy újságíró profilját, itt az email és név mellett szerepeljen:
- hogy olvasói vagy újságírói profil
- minden cikk ID-ja és címe, amit értékelt az felhasználó, és az adott értékelés
- minden cikk ID-ja és címe, ami alá kommentelt az felhasználó, és a hozzá tartozó kommentek száma
- újságíró esetén minden általa írt cikk ID-ja és címe, időrendben csökkenő sorrendben

## Címlap

A Hírharsona szeretné a weboldalának címlapján különböző feltételek alapján leszűrve megjeleníteni kiemelt cikkeket:
- legfrissebb 10 cikk
- legjobban értékelt 10 cikk
- legjobban értékelt 10 cikk, ami nem régebbi 3 napnál

## Időzített cikkek

Legyen lehetőség a cikkekhez megadni egy “élesítés időpontja” mezőt.
Az összes cikk megjelenítése kivételével, tehát a címlap funkciókban és a szerzők profiloldalánál csak olyan cikkek jelenjenek meg, amiknél az élesítés időpontja üresen lett hagyva, vagy már múltbeli az időpont.

## Kulcsszó rendszer

*Egyszerűbb változat:* minden cikknek meg lehet adni egy előre rögzített listából egy kategóriát (például közélet, tudományos, bulvár, politika, stb). A cikkek listázásánál és a teljes cikk megjelenítésénél is adjuk vissza a kategóriát is.
Emellett lehet a cikkekre kategória alapján is keresni, ilyenkor adjuk vissza az összes olyan cikk listáját, ami az adott kategóriához tartozik.

*Bonyolultabb változat:* a cikkekhez kulcssszavakat lehet rögzíteni. A kulcsszavak nincsenek meghatározva előre, és minden cikkhez többet is fel lehet venni. A kulcsszavakat a cikkek rögzítésekor és módosításkor is be lehet állítani.
A kulcsszavakat a cikkek listázásánál és a teljes cikk megjelenítésénél is adjuk vissza a válaszban. Emellett legyen lehetőség kulcsszó alapján listázni a cikkeket.

## Admin funkciók

Az alkalmazásba kerüljön be egy harmadik jogosultsági szint, az ADMIN is. ADMIN-ként ne lehessen regisztrálni, csak közvetlenül az adatbázisban módosítva lehet beállítani.
Adminként van lehetőség módosítani és törölni regisztrációkat is. Törlés esetén ne történjen tényleges törlés, csak logikai, de a megadott felhasználóval ne lehessen bejelentkezni többet az alkalmazásba, illetve legyünk GDPR kompatibilisek, és a regisztrációhoz tartozó személyes adatok (név, emailcím) legyenek törölve az adatbázisból.
Cikk vagy komment megjelenítésekor a szerző neve helyett legyen az ```*inaktív regisztráció*``` szöveg megjelenítve ilyenkor.

## Módosítások története (nehéz!)
A rendszerben történt módosítások és törlések dátumából nem csak a legutolsót akarjuk eltárolni, hanem az összes módosítást.
Figyelem! Nem triviális feladat, több új adatbázistáblát is létre kell hozni hozzá, és át kell gondolni minden folyamat lépéseit.
