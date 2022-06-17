import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomePageComponent } from './pages/admin-home-page/admin-home-page.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';
import { PatientHomePageComponent } from './pages/patient-home-page/patient-home-page.component';
import { RegistrationComponent } from './pages/registration/registration.component';

const routes: Routes = [
  { path: '', pathMatch:'full', redirectTo:'landingPage'},
  { path: 'landingPage', component: LandingPageComponent},
  { path: 'registration', component: RegistrationComponent},
  { path: 'login', component: LoginComponent},
  { path: 'patientHomePage', component: PatientHomePageComponent},
  { path: 'patientHomePage/:token', component: PatientHomePageComponent},
  { path: 'adminHomePage', component: AdminHomePageComponent},
  { path: 'login/:token', component: LoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
