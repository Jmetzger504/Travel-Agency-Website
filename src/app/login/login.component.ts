import { Component, OnInit } from '@angular/core';
import {Validators,FormGroup,FormBuilder} from '@angular/forms';
import { Router } from '@angular/router';
import { GlobalService } from '../services/global.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide:boolean = true;
  confirmation: string = "";
  router:Router;
  loginForm: FormGroup;
  ngOnInit(): void {
  }

  constructor(private fb: FormBuilder, private service: GlobalService,private routerRef:Router) {

    this.router = routerRef;
    this.confirmation = "";
    this.service.loggedIn = false;
    this.loginForm = this.fb.group({
      email: ['',[
        Validators.required,
        Validators.email
      ]],
      password: ['',[
        Validators.required,
      ]],
    })
   }

  login() {
    try {
      this.service.login(this.loginForm.get('email')?.value,
        this.loginForm.get('password')?.value).subscribe(data => {
          
          
          if(data == null) {
            this.confirmation = "Invalid credentials";
            console.log("you goofed.");
          }
          else { 
            this.service.Customer = data;
            this.service.loggedIn = true;
            this.router.navigateByUrl("/home");
        }
    });
    
    }
    catch(ex:any) {
      this.confirmation = "Something has gone terribly wrong :'(";
      }
    

    
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

}
