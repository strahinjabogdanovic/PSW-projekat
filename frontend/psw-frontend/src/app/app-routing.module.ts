import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { RegistrationComponent } from './pages/registration/registration.component';

const routes: Routes = [
  { path: '', pathMatch:'full', redirectTo:'landingPage'},
  { path: 'landingPage', component: LandingPageComponent},
  { path: 'registration', component: RegistrationComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
