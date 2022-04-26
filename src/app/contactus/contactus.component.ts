import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contactus',
  templateUrl: './contactus.component.html',
  styleUrls: ['./contactus.component.css']
})
export class ContactusComponent implements OnInit {
 
  cruises:any = [{From: "New Orleans, Louisiana",
  To: "Cozumel, Mexico",
  shipName: "Boat",
  cruiseLine: "Carnival", 
  dayLength: 5,
  rooms: [{roomType: "The Brig", available: 100, total: 500, roomPrice: 0},
      {roomType: "Suite", available: 30, total: 30,roomPrice: 5000}],
  departureDate: [new Date("2022-05-05 10:00 AM")],
  arrivalDate: [new Date("2022-05-10 10:00 AM")],
  pricePerAdult: 500,
  pricePerChild: 100,
  itinerary: [{day: 1,city: "New Orleans",country: "Louisiana, United States",portTime: "10:00AM"},
              {day: 2, city: "At Sea", country: "",portTime:""},
              {day: 3, city: "Cozumel", country: "Mexico",portTime:"10:00AM"},
              {day: 4, city: "At Sea", country: "",portTime:""},
              {day: 5,city: "New Orleans",country: "Louisiana, United States",portTime: "4:00PM"}
            ]
}];

  constructor() { }

  ngOnInit(): void {
  }

}
