import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CruiseTicket } from '../models/cruiseticket.model';
import { Voyage } from '../models/voyage.model';
@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  _http:HttpClient;
  loggedIn:boolean;
  rooms:number = 0;
  destinations = [];
  Voyages: Voyage[] = [];
  Voyage:Voyage = new Voyage();

  Customer: any  = {
    id: 0,
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    streetAddress: "",
    state: "",
    zipCode: 0,
    balance: 0};

  myVoyages: Voyage[] = [];
  
  cruiseTickets: CruiseTicket[] = [];
  cruiseTicket = {id: 0, voyageId: 0, custId: 0, shipId: 0, rooms: 0,childGuests: 0,adultGuests: 0,
    totalCost: 0}

  connectionString: string = "https://localhost:7004/api/"
  constructor(private _httpRef:HttpClient) {
    this._http = _httpRef;
    this.loggedIn = false;
   }
   
  canActivate(): boolean {
    if(this.loggedIn)
      return true;
    return false;
  }

   register(firstName:string,lastName:string,email:string,password:string,
    streetAddress:string, city:string,state:string,zipCode:number,
    balance:number) {


     this.Customer = {Id: 0,firstName:firstName,lastName:lastName,email:email,password:password,
      streetAddress:streetAddress,city:city,state:state,zipCode:zipCode,balance:balance}
      return this._http.post(this.connectionString + "CustomerDetails/Register",this.Customer);
   }

   login(email?:string,password?:string) {
     return this._http.get(this.connectionString + 'CustomerDetails/' + email + "/" + password);
   }

  getLocations() {
    return this._http.get(this.connectionString + 'CruiseShip/getLocations');
  }

  searchByLocation(location:string) {
    return this._http.get(this.connectionString + 'CruiseShip/SearchByLocation' + location);
  }

  getVoyages() : Observable<any> {
    return this._http.get(this.connectionString + 'Voyages/getVoyages');
  }

  getMyTickets() : Observable<any> {
    return this._http.get(this.connectionString + "CruiseTicket/getMyTickets" + this.Customer.id);
  }

  purchaseTicket() {
    return this._http.post(this.connectionString + "CustomerDetails/purchaseTicket",this.cruiseTicket);
  }

}
