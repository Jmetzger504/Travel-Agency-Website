import { Component, OnInit } from '@angular/core';
import { GlobalService } from '../services/global.service';

@Component({
  selector: 'app-cruiseconfirmation',
  templateUrl: './cruiseconfirmation.component.html',
  styleUrls: ['./cruiseconfirmation.component.css']
})
export class CruiseconfirmationComponent implements OnInit {

  service:GlobalService;

  constructor(serviceRef:GlobalService) {
    this.service = serviceRef;
   }

  

  ngOnInit(): void {
  }

}
