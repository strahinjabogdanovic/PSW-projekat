import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/user.service';

interface Gender {
  value: string;
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  validateForm!: FormGroup;
  username: string = "";
  name: string = "";
  surname : string = "";
  password : string = "";
  checkPassword : string = "";
  phone : string = "";
  jmbg : string = "";
  address : string = "";
  selectedValueGender = "Male";

  hide: boolean = true;
  hideRp: boolean = true; 

  constructor(private fb: FormBuilder, private router: Router, private  userService: UserService) { }

  //validacija za polja ako su prazna
  ngOnInit(): void {
    this.validateForm = this.fb.group({
      username: [null,[Validators.required]],
      name: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      password: [null, [Validators.required]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
      phone: [null, [Validators.required]],
      jmbg: [null, [Validators.required]],
      address: [null, [Validators.required]]
    });
  }

  confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls['password'].value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  genders: Gender[] = [
    {value: 'Male'},
    {value: 'Female'},
  ];

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    this.username = this.validateForm.value.username;
    this.name = this.validateForm.value.name;
    this.surname = this.validateForm.value.surname;
    this.password = this.validateForm.value.password;
    this.phone = this.validateForm.value.phone;
    this.checkPassword = this.validateForm.value.checkPassword;
    this.jmbg = this.validateForm.value.jmbg;
    this.address = this.validateForm.value.address;

    const body = {
      username: this.username,
      name: this.name,
      surname: this.surname,
      password : this.password,
      repeatPassword: this.checkPassword,
      phone : this.phone,
      gender: this.selectedValueGender,   
    }
/*
    if(this.validateForm.valid){
      this.userService.registration(body).subscribe(data => { 
          alert("Registration successful");
          this.router.navigate(['login']);
      }, error => {
        console.log(error.status);
        alert("Registration unsuccessful");
      });
    }*/
  }
}
