import { Component, OnInit } from '@angular/core';
import {Validators,FormGroup,FormBuilder} from '@angular/forms';
import { Router } from '@angular/router';
import { GlobalService } from '../services/global.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  router:Router;
  hide:boolean = true;
  registerForm: FormGroup;
  confirmation:string = "";
  ngOnInit(): void {
    
  }

  constructor(private fb: FormBuilder,private service: GlobalService, routerRef: Router) {
    this.router = routerRef;
    this.registerForm = this.fb.group({
      firstName: ['',[
        Validators.required,
        Validators.minLength(2)
      ]],
      lastName: ['',[
        Validators.required,
        Validators.minLength(2)
      ]],
      email: ['',[
        Validators.required,
        Validators.email
      ]],
      password: ['',[
        Validators.required,
        Validators.minLength(8),
        Validators.pattern("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")
      ]],
      streetAddress: ['',[Validators.required]],
      city: ['',Validators.required],
      state: ['',[Validators.required]],
      zipCode: ['',[
        Validators.required,
        Validators.minLength(5),
      ]],
      balance: ['',[
        Validators.required,
        Validators.min(0),
        
      ]],
    });

    this.registerForm.valueChanges.subscribe();
  }


  get firstName() {
    return this.registerForm.get('firstName');
  }

  get lastName() {
    return this.registerForm.get('lastName');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get streetAddress() {
    return this.registerForm.get('streetAddress');
  }

  get city() {
    return this.registerForm.get('city');
  }

  get state() {
    return this.registerForm.get('state');
  }

  get zipCode() {
    return this.registerForm.get('zipCode');
  }

  get balance() {
    return this.registerForm.get('balance');
  }
  
  register() {
    this.service.register(this.registerForm.get('firstName')?.value,
    this.registerForm.get('lastName')?.value,
    this.registerForm.get("email")?.value,
    this.registerForm.get('password')?.value,
    this.registerForm.get("streetAddress")?.value,
    this.registerForm.get('city')?.value,
    this.registerForm.get("state")?.value,
    this.registerForm.get("zipCode")?.value,
    this.registerForm.get("balance")?.value).subscribe(data => {
      if(data == null) {
        this.confirmation = "This account already exists!";
        console.log("Silly!")
      }
      else this.service.Customer = data;
      this.service.loggedIn = true;
      this.router.navigateByUrl("/home");
    });
  }
}
