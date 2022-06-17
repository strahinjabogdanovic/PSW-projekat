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
  public token: any;
  validateForm!: FormGroup;
  hide: boolean = true;
  //role: string = "";
  public decodedToken :any;

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private router: Router, private userService : UserService) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]]
    });
    //this.getToken();
    //const token = this.route.snapshot.params['token'];
    
   /* const token = this.route.snapshot.params['token'];
    if (token != undefined) {
      this.rrService.confirmRegistrationRequest(token).subscribe(() => {
        this.router.navigateByUrl(`/login`);
      },
        error => {
        });
    }*/
  }



  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    this.userDto.Username = this.validateForm.value.username;
    this.userDto.Password = this.validateForm.value.password;
    console.log(this.userDto.Username)
    
    /*this.userService.login(this.userDto).subscribe(data => {
      const user = data;
      localStorage.setItem('user', JSON.stringify(user));
      localStorage.setItem('token', JSON.stringify(user.token));
      
      sessionStorage.setItem('username', user.username);
      let authString = 'Basic ' + btoa(user.username + ':' + user.password);
      sessionStorage.setItem('basicauth', authString);
      console.log(this.getDecodedAccessToken(data.token));
      console.log(data.token);
      if(this.getDecodedAccessToken(user.token)['Role'] === 'PATIENT'){
        this.router.navigate(['patientHomePage']);
      }
      else if(this.getDecodedAccessToken(user.token).Role === 'ADMIN'){
        this.router.navigate(['adminHomePage']);
      }
    }, error => {
        alert(error);
    })*/

    this.userService.login(this.userDto).subscribe((data: any)=>{
      localStorage.setItem("jwtToken", data);
      let tokenInfo = this.getDecodedAccessToken(data);
      if(tokenInfo !== null){
      console.log(tokenInfo);
      localStorage.setItem('Id', tokenInfo.Id);
      localStorage.setItem('Role', tokenInfo.Role);
      console.log(data)
      console.log(tokenInfo.Role)
      console.log(data.role)
      if((tokenInfo.Role) === 'PATIENT'){
        this.router.navigate(['patientHomePage']);
      }
    }
      else {
        this.router.navigate(['adminHomePage']);
      }
    });
  


  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
      console.log(jwt_decode(token));
    }
    catch (Error) {
      return null;
    }
  }
  
}
