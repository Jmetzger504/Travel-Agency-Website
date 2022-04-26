import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutusComponent } from './aboutus/aboutus.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MyaccountComponent } from './myaccount/myaccount.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { RegisterComponent } from './register/register.component';
import { GlobalService } from './services/global.service';
import { LogoutComponent } from './logout/logout.component';
import { ContactusComponent } from './contactus/contactus.component';
import { MainNavComponent } from './main-nav/main-nav.component';

const routes: Routes = [
  {path:'logout',component:LogoutComponent,canActivate:[GlobalService]},
  {path: 'login',component: LoginComponent},
  {path: 'myaccount',component: MyaccountComponent},
  {path: 'register',component: RegisterComponent},
  {path: 'home',component: HomeComponent},
  {path: '', component: LoginComponent},
  {path: 'aboutus',component: AboutusComponent},
  {path: 'contactus',component: ContactusComponent},
  {path: 'main-nav',component: MainNavComponent},   
  {path: '**', component: NotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }