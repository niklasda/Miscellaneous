
class Towns
{
	public var locationId:Number;
	public var subLocationId:Number;
	public var locationName:String;
	
	public static function PrintLocationMessage(currentLocation:String):String
	{
		//trace("hej");
		var message:String;
		switch(currentLocation)
		{
			case "1.1":
				message  = "You are at Malmö central station, where do you want to go now?\n";
				message += "Press left for Home\n";
				message += "Press right for Hospital\n";
				message += "Click on a Town to take the train there.\n";
			break;
			case "1.2":
				message  = "You are at Malmö home, where do you want to go now?\n";
				message += "Press left for -\n";
				message += "Press right for station\n";
			break;
			case "1.3":
				message  = "You are at Malmö hospital, where do you want to go now?\n";
				message += "Press left for station\n";
				message += "Press right for -\n";
			break;
			case "2.1":
				message  = "You are at Simrishamn station, where do you want to go now?\n";
				message += "Press left for fishery\n";
				message += "Press right for harbour\n";
				message += "Click on a Town to take the train there.\n";
			break;
			case "2.2":
				message  = "You are at Simrishamn fishery, where do you want to go now?\n";
				message += "Press left for -\n";
				message += "Press right for station\n";
			break;
			case "2.3":
				message  = "You are at Simrishamn harbour, where do you want to go now?\n";
				message += "Press left for station\n";
				message += "Press right for -\n";
			break;
			case "3.1":
				message  = "You are at Laholm station, where do you want to go now?\n";
				message += "Press left for factory\n";
				message += "Press right for hotel\n";
				message += "Click on a Town to take the train there.\n";
			break;
			case "3.2":
				message  = "You are at Laholm factory, where do you want to go now?\n";
				message += "Press left for -\n";
				message += "Press right for station\n";
			break;
			case "3.3":
				message  = "You are at Laholm hotel, where do you want to go now?\n";
				message += "Press left for station\n";
				message += "Press right for -\n";
			break;
			case "4.1":
				message  = "You are at Karlskrona station, where do you want to go now?\n";
				message += "Press left for store\n";
				message += "Press right for hotel 2\n";
				message += "Click on a Town to take the train there.\n";
			break;
			case "4.2":
				message  = "You are at Karlskrona store, where do you want to go now?\n";
				message += "Press left for -\n";
				message += "Press right for station\n";
			break;
			case "4.3":
				message  = "You are at Karlskrona hotel 2, where do you want to go now?\n";
				message += "Press left for station\n";
				message += "Press right for -\n";
			break;
			case "5.1":
				message  = "You are at Klippan station, where do you want to go now?\n";
				message += "Press left for bank\n";
				message += "Press right for dump\n";
				message += "Click on a Town to take the train there.\n";
			break;
			case "5.2":
				message  = "You are at Klippan bank, where do you want to go now?\n";
				message += "Press left for -\n";
				message += "Press right for station\n";
			break;
			case "5.3":
				message  = "You are at Klippan dump, where do you want to go now?\n";
				message += "Press left for station\n";
				message += "Press right for -\n";
			break;
			case "6.1":
				message  = "You are at Vittsjö station, where do you want to go now?\n";
				message += "Press left for pub\n";
				message += "Press right for convent\n";
				message += "Click on a Town to take the train there.\n";
			break;
			case "6.2":
				message  = "You are at Vittsjö pub, where do you want to go now?\n";
				message += "Press left for -\n";
				message += "Press right for station\n";
			break;
			case "6.3":
				message  = "You are at Vittsjö convent, where do you want to go now?\n";
				message += "Press left for station\n";
				message += "Press right for -\n";
			break;
		}
		return message;
	}
}

/*

1. Malmö
1.1	central station
1.2 home, your apartment
1.3 hospital (no use to go there???, since you end up here automatically when hurt)

2. Simrishamn
2.1 railroad station
2.2 fish-rensery, earn 10€ per hour (fishery???, fish-guttery???)
2.3 harbour, dive for gold, requires diving equipment to succeed, whatch out for sharks

3. Laholm
3.1 train station
3.2 factory, what factory???, earn 15€ per hour
3.3 sheap hotel, sleep here for 8€ per night

4. Karlskrona
4.1 railroad station
4.2 general store, buy diving equipment for 200€ (tripples air time, possible to re-use)
4.3 regular hotel, sleep here for 12€ per night

5. Klippan
5.1 train station
5.2 small town bank, borrow money between 10€ - 100€ (if you have not been to jail), pay back in 3 days
5.3 big dump, possible to find diving graded equipment (doubles diving time), or get attacked by low-lifes

6. Vittsjö
6.1 train station
6.2 sleazy country pub, play poker machine och get into trouble with local drunkards
6.3 religious convent of pingst friends??? get in contact with ancestors (useless) or get screwed


the game is turn-based and one turn is one hour.

when diving a turn is one minute, and it's possible to dive for 10 minutes without equioment???

you can travel to any place from any other place in one??? hour.

Game-day starts at 07:00 at home, at a hotel or in the hospital.

Game-day end at 23:00 at home or at a hotel or when struck down by low-lifes.

If you are now safely in-doors at 23:00 you might be attacked, robbed, killed, abducted, get into drugs etc.

Does the game end when put in jail?

*/