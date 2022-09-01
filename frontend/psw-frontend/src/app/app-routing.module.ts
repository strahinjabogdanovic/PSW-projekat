import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomePageComponent } from './pages/admin-home-page/admin-home-page.component';
import { AppointmentObserveComponent } from './pages/appointment-observe/appointment-observe.component';
import { CommentComponent } from './pages/comment/comment.component';
import { DoctorHomePageComponent } from './pages/doctor-home-page/doctor-home-page.component';
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { LoginComponent } from './pages/login/login.component';
import { PatientHomePageComponent } from './pages/patient-home-page/patient-home-page.component';
import { RecommendAppointmentComponent } from './pages/recommend-appointment/recommend-appointment.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { SpecialistAppointmentComponent } from './pages/specialist-appointment/specialist-appointment.component';
import { SurveyComponent } from './pages/survey/survey.component';
import { UserListComponent } from './pages/user-list/user-list.component';

const routes: Routes = [
  { path: '', pathMatch:'full', redirectTo:'landingPage'},
  { path: 'landingPage', component: LandingPageComponent},
  { path: 'registration', component: RegistrationComponent},
  { path: 'login', component: LoginComponent},
  { path: 'patientHomePage', component: PatientHomePageComponent},
  { path: 'patientHomePage/:token', component: PatientHomePageComponent},
  { path: 'adminHomePage', component: AdminHomePageComponent},
  { path: 'login/:token', component: LoginComponent},
  { path: 'recommendedAppointment', component: RecommendAppointmentComponent},
  { path: 'observeAppointments/:token', component: AppointmentObserveComponent},
  { path: 'observeAppointments', component: AppointmentObserveComponent},
  { path: 'specialistAppointment', component: SpecialistAppointmentComponent},
  { path: 'survey', component: SurveyComponent},
  { path: 'survey/:id/:ap', component: SurveyComponent},
  { path: 'comments', component: CommentComponent, pathMatch: 'full'},
  { path: 'userList', component: UserListComponent},
  { path: 'doctorHomePage', component: DoctorHomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
