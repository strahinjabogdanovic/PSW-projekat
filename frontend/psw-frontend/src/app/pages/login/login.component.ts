import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import jwt_decode from 'jwt-decode';
import { UserService } from 'src/app/user.service';
import { UserDto } from './user.dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userDto: UserDto = { Username: "", Password: ""}

  loginForm: FormGroup;
  hide: boolean = true;

  constructor(private loginService: UserService, private router: Router,private formBuilder: FormBuilder) { 
    this.loginForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  onSubmit() {
    this.loginService.login(this.userDto).subscribe((data: any)=>{
      localStorage.setItem("jwtToken", data);
      let tokenInfo = this.getDecodedToken(data);
      localStorage.setItem('Id', tokenInfo.Id);
      localStorage.setItem('Role', tokenInfo.Role);
      localStorage.setItem('Username', tokenInfo.Username);
      localStorage.setItem('Password', tokenInfo.Password);
      if(localStorage.getItem('Password') !== this.userDto.Password){
        alert("Pogresna lozinka!");
      }
      console.log(tokenInfo.Role);
      console.log(data);
      if(localStorage.getItem('Role') === 'PATIENT'){
        this.router.navigate(['/observeAppointments']);
      }else if(localStorage.getItem('Role') === 'DOCTOR'){
        this.router.navigate(['/doctorHomePage']);
      }
      else
      {
        this.router.navigate(['/landingPage']);
      }
    });

  
  }

  getDecodedToken(token: string): any{
    try{
      return jwt_decode(token);
    }
    catch(Error){
      token = "";
    }
  }

  register(){
    this.router.navigate(['/registration']);
  }
} 