import { Itinerary } from "./Itinerary.model";


export class CruiseShip {
    id: number = 0;
    portCity: string = "";
    portState: string = "";
    shipName: string = "";
    cruiseLine: string = "";
    adultPrice: number = 0;
    childPrice: number = 0;
    roomPrice: number = 0;
    tripLength: number = 0;
    img1: string = "";
    img2: string = "";
    img3: string = "";
    img4: string = "";
    itineraries: Itinerary[] = [];
}