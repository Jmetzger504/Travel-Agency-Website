import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';

@Component({
  selector: 'app-myaccount',
  templateUrl: './myaccount.component.html',
  styleUrls: ['./myaccount.component.css']
})
export class MyaccountComponent implements OnInit {

  service:GlobalService
  message: string = "";

  constructor(serviceRef:GlobalService) {
    this.service = serviceRef;
    this.service.getMyTickets().subscribe(data => {
      if(data.length == 0)
        this.message = "Sorry, you don't seem to have any cruises booked currently!";
      this.service.cruiseTickets = data;
      console.log(this.service.cruiseTickets);
    });
   }

  ngOnInit(): void {

  }

  

}
