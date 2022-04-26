import { CruiseShip } from "./cruiseship.model";

export class Voyage {
    id: number = 0;
    shipId: number = 0;
    departure:Date = new Date();
    arrival:Date = new Date(0);
    roomsAvailable: number = 0;
    totalRooms: number = 0;
    destination: string = "";
    cruiseShip:CruiseShip = new CruiseShip();
}