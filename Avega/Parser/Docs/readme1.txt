Alternativ 1: Ranka ord

Uppgiften består av att ranka ord i dokument av olika typ. Programmet ska ta som input ett antal sökvägar till dokument i filsystemet och som resultat 
generera en rapport över de 5 högst rankade orden. Följande krav finns på applikationen:

- Programmet ska stödja två typer av dokument, Text-filer samt HTML-filer
- Filtypen framgår av fil-ändelsen (.txt för plain text, .html för HTML)
- För HTML-dokument ska endast “textnoder” räknas, dvs html-element och deras attribut behöver inte räknas.
- Programmet ska ta sökvägar i filsystemet till dokument via standard in. En sökväg per rad. En tom rad indikerar slutet på input var efter resultatet ska genereras och applikationen kan avslutas.
- Om en fil inte går att läsa pga rättigheter eller fel format ska ändå programmet fortsätta med nästa fil
- Programmet ska kunna hantera stora mängder data samt stort antal filer

Rankningsregler
- Varje ord ska tilldelas ett poäng för varje förekomst
- Ord på 4 bokstäver eller mindre ska ej räknas till resultatet
- Ord som är mer än 10 bokstäver långa ska ej räknas till resultatet, men innehåller ordet bindesträck “-” så är gränsen 20 bokstäver.
- Om ett dokument innehåller mer än 100 ord ska alla ord i det aktuella dokumentet få ett extra poäng
- Om ett dokument innehåller mer än 1000 ord ska alla ord med dubbla bokstäver tilldelas ytterligare en extra poäng.

Du väljer själv hur du vill presentera resultatet, följande är ett exempel
> RankWords.exe 
> document.txt 
> document2.html 
> 
> 
1. about (500) 
2. would (400) 
3. which (300) 
4. other (220) 
5. there (100)
