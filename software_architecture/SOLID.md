# 19. SOLID tervezési elvek
 
![img.png](img.png)

### Mi az a SOLID?
A `SOLID` egy tervezési elvek nevéből képzett mozaikszó, amit ez a tapasztalt programozási guru `Robert C. Martin` talált ki azért, hogy a szoftverek könnyebben megérthetőek és karbantarthatók maradjanak.
Az elvek:
- `Single Responsibility` principle – Egy felelősség elv
- `Open/Closed` principle (*1980s*) – Nyílt/zárt elv
- `Liskov substitution` principle (*1988*) – Liskov helyettesítési elv
- `Interface segregation` principle – Interface elválasztási elv
- `Dependency inversion` principle – Függőség megfordítási elv 

### Mégis mi ez az egész, és mire jó nekünk??

Az épületeket például téglák alkotják, ám ha ezeknek a tégláknak szar a minősége, akkor hiába jó az épület architektúrája, a modulok gyenge minősége miatt összedőlhet.
Ellenben jó alaposan megmunkált téglákkal is lehet nagy rendetlenséget csinálni.

Itt jön képbe a SOLID, ő fogja nekünk megmondani, hogy ezeket az építőelemeket – függvényeket, adatszerkezeteket hogyan rendezzük osztályokba, és azok az osztályok hogyan kommunikáljanak egymással.

Azonban az osztály szó láttán nehogy azt gondold, hogy a SOLID elveket csak objektum-orientált nyelvekre lehet alkalmazni. Az osztály szó mindössze adatok és függvények csoportját jelenti. Minden software system tartalmaz ilyen csoportokat, ha osztálynak hívjuk őket, ha nem.
Na a SOLID elvek ezekere a csoportokra/grouppokra vonatkoznak.
Az elvek célja, hogy egy olyan `mid-level` (kód feletti – modul szintű) software structure-t alkossunk, ami:

- elviseli a változást
- könnyen érthető
- számos szoftverrendszerben használható komponensek alapjai.

## SRP: THE SINGLE RESPONSIBILITY PRINCIPLE

Egy felelősség elve, minden modul/osztály/függvény csak egy dolgot csináljon.

Ha neked is ezek a szavak jutnak eszedbe az SRP-ről, akkor sajnos nem érted ezt az elvet,
ugyanis a SOLID elvek közül ezt értik a legkevésbé az emberek, lehet pont a neve miatt.
Történelmileg az SRP az alábbi módon lett definiálva:

`Egy modulnak egy, és csak egy oka lehet a változásra.`

Egy software system azért változik, hogy kielégítsen bizonyos felhasználói és érdekelt felek igényeit.
Mivel lehet több felhasználó és érdekelt személy is, aki ugyanazt a változtatást szeretné,
így ők egy csoport is lehetnek. Ezet a személyt/személyeket/csoportot a továbbiakban szereplőnek hívjuk. Tehát:

`Egy modul csak egy, és csak egy szereplőnek lehet felelős.`

És mi az a modul? A legegyszerűbb jelentése egy forrásfájl, vagy összefüggő függvények és adatszerkezetek csoportja.
Az összefüggő szó jelenti az `SRP`-t, ezek az összefüggő részek felelősek kizárólag egy `szereplőnek`.
A legjobb módszer, hogy megértsük ezt az elvet az, ha az elv megsértésére nézünk példákat.

### Megsértés 1: véletlen duplikáció

Népszerű példa az Employee osztály egy bérszámítás alkalmazásból.

<br>
<br>
<br>

#### Forrás: *Clean Architecture - Robert C. Martin @2018*
