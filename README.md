# GWVACB_HFT_2023241

## Áttekintés

Ez a projekt egy olyan alkalmazás, amely egy ASP.NET Core alapú REST API-t tartalmaz, amelyhez kapcsolódik egy egyszerű konzolos menüfelülettel rendelkező kliensalkalmazás. Az alkalmazás rétegei között szerepelnek a Repository, Logic, Test, Endpoint, Client és Model rétegek.

## Rétegek

Az alkalmazás különböző rétegekből áll, amelyek különféle felelősségi területeket fednek le:

1. **Repository**: Az ASP.NET Core REST API rétege, amely az adatokat kezeli és kiszolgálja.

2. **Logic**: Az alkalmazás üzleti logikáját tartalmazza, ami az adatok feldolgozásáért és az üzleti szabályok végrehajtásáért felelős.

3. **Test**: A tesztek rétege, amely lefedi az összes létrehozási (create) és nem CRUD (create, read, update, delete) műveletet.

4. **Endpoint**: Az API végpontokat definiálja, amelyek a kliens és a szerver közötti kommunikációt biztosítják.

5. **Client**: Az egyszerű konzolos menüfelülettel rendelkező kliensalkalmazás, amely lehetővé teszi a CRUD és nem CRUD műveletek elérését az API végponton keresztül. A kommunikáció JSON alapú és HTTP protokollt használ.

6. **Model**: Az adatmodell rétege, amely a használt adatstruktúrákat és entitásokat tartalmazza.

## Adatbázis

Az adatbázis három táblát tartalmaz:

1. **Author**: Az írókat reprezentáló tábla, amely tartalmazza az azonosítót, nevet, kort és országot.

2. **Quote**: Az idézeteket reprezentáló tábla, amely tartalmazza az azonosítót, az író azonosítóját, a címet és a tartalmat.

3. **Comment**: A kommenteket reprezentáló tábla, amely tartalmazza az azonosítót, a tartalmat és az idézet azonosítóját.

## Tesztek

A projekt teljes körű tesztelést tartalmaz, amely lefedi az összes létrehozási (create) és nem CRUD műveletet, biztosítva ezzel az alkalmazás megbízhatóságát és funkcionalitását.

---
A projekt egy féléves házi feladat  Haladó Fejlesztés Techinikák tárgyra. A projektet készítette: **Tánczos János** (GWVACB)