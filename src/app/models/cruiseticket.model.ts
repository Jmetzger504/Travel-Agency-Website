import { Voyage } from "./voyage.model";

export class CruiseTicket {
    id: number = 0;
    voyageId: number = 0;
    custId: number = 0;
    shipId: number = 0;
    rooms: number = 0;
    childGuests: number = 0;
    adultGuests: number = 0;
    totalCost: number = 0;
    myVoyage: Voyage = new Voyage();
}