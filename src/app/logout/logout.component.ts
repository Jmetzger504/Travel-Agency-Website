import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GlobalService } from '../services/global.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  service:GlobalService;
  router:Router;
  constructor(serviceRef:GlobalService,private routerRef:Router) {
    
    this.service = serviceRef;
    this.service.loggedIn = false;
    this.service.Customer = null;
    this.router = routerRef;
    this.router.navigateByUrl("/login");
   }

  ngOnInit(): void {
  }

}
