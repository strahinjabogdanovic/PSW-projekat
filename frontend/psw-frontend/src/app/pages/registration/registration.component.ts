import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/user.service';
import { RegistrationDTO } from './registration.dto';

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
  address : string = "";
  jmbg : string = "";
  selectedValueGender = "Male";
  hide: boolean = true;
  role: string = "";
  public register: RegistrationDTO = new RegistrationDTO();

  constructor(private fb: FormBuilder,private userService : UserService, private router: Router) { }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      username: [null,[Validators.required]],
      name: [null, [Validators.required]],
      surname: [null, [Validators.required]],
      password: [null, [Validators.required]],
      phone: [null, [Validators.required]],
      address: [null, [Validators.required]],
      jmbg: [null, [Validators.required]]
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
    {value: 'Female'}
  ];

  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    this.register.Name = this.validateForm.value.name;
    this.register.Surname = this.validateForm.value.surname;
    this.register.Username = this.validateForm.value.username;
    this.register.Password = this.validateForm.value.password;
    this.register.Phone = this.validateForm.value.phone;
    this.register.Jmbg = this.validateForm.value.jmbg;
    this.register.Address = this.validateForm.value.address;
    this.register.Gender = this.selectedValueGender;
    console.log(this.register.Gender)
      if(this.validateForm.valid){
        this.userService.registration(this.register).subscribe(data => { 
            alert("Registration successfull");
            this.router.navigate(['login']);
        }, error => {
          console.log(error.status);
          if(error.status == 409){
            alert("Username already exists");
          }
        });
      }
    }
}
