import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';
import {Validators,FormGroup,FormBuilder} from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { CruiseconfirmationComponent } from '../cruiseconfirmation/cruiseconfirmation.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  
  service:GlobalService;
  locationForm:FormGroup;
  dateForm:FormGroup;
  travelerForm:FormGroup;
  locations: any;
  confirmation: string = "";
  constructor(serviceRef: GlobalService,private fb: FormBuilder, private snackBar: MatSnackBar, public dialog: MatDialog) {
    this.service = serviceRef;
    this.service.cruiseTicket.adultGuests = 2;
    this.service.cruiseTicket.childGuests = 0;
    this.service.cruiseTicket.rooms = 1;
    this.locationForm = this.fb.group({
      formLocations: ['',Validators.required]
    })
    this.service.getLocations().subscribe(data => {
      this.locations = data;
     });
     this.dateForm = this.fb.group({
       formDates: ['',Validators.required]
     });
     this.travelerForm = this.fb.group({
        formAdults: [2,[Validators.required,Validators.min(1)]],
        formChildren: [0,[Validators.required,Validators.min(0)]],
        formRooms: [1,[Validators.required,Validators.min(1),Validators.max(4)]]
     })
     this.travelerForm.valueChanges.subscribe();
     this.service.getVoyages().subscribe(data => {
      this.service.Voyages = data;
      // console.log(this.service.Voyages);
      // console.log(this.service.Voyages[0].cruiseShip);
    });
   }

   openDialog() {
    this.dialog.open(CruiseconfirmationComponent);
  }

  get formLocations() {
    return this.locationForm.get('formLocations');
  }

  searchByLocation() {
  
  }

  assembleTravelers() {
    this.snackBar.open("Travelers updated!","Ok");
    this.service.cruiseTicket.childGuests = this.travelerForm.get("formChildren")?.value;
    this.service.cruiseTicket.adultGuests = this.travelerForm.get("formAdults")?.value;
    this.service.cruiseTicket.rooms = this.travelerForm.get("formRooms")?.value;
    // console.log(this.service.cruiseTicket.childGuests);
    // console.log(this.service.cruiseTicket.adultGuests);
  }

  chooseCruise(i:number) {
    this.service.Voyage = this.service.Voyages[i];
    console.log(this.service.Voyage);
    this.service.cruiseTicket.custId = this.service.Customer.id;
    this.service.cruiseTicket.voyageId = this.service.Voyage.id;
    this.service.cruiseTicket.shipId = this.service.Voyage.shipId;
    this.service.cruiseTicket.totalCost = this.service.cruiseTicket.adultGuests * this.service.Voyage.cruiseShip.adultPrice
     + this.service.cruiseTicket.childGuests * this.service.Voyage.cruiseShip.childPrice 
     + this.service.cruiseTicket.rooms * this.service.Voyage.cruiseShip.roomPrice;
    this.service.purchaseTicket().subscribe(data => {
      if(data == null)
      console.log("dang :(");
      this.openDialog();
    });
    
  }

  ngOnInit(): void {
    
  }

}
