import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { RecommendAppointmentService } from 'src/app/recommend-appointment.service';
import { DoctorHomePageComponent } from '../doctor-home-page/doctor-home-page.component';
import { RecipeDto } from './recipe.dto';

@Component({
  selector: 'app-give-recipe',
  templateUrl: './give-recipe.component.html',
  styleUrls: ['./give-recipe.component.css']
})
export class GiveRecipeComponent implements OnInit {
  recipeDto: RecipeDto = { IdR: 0, Medicine: "", Quantity: "", Instructions: ""}
  recipeForm: FormGroup;
  public id: any = "";
  public idR: number = 0;
  public medicine: string = "";
  public quantity: string = "";
  public instructions: string = "";

  constructor(private router: Router, private formBuilder: FormBuilder, private recommendAppointmentService: RecommendAppointmentService, private dialogRef: MatDialogRef<GiveRecipeComponent>) { 
    this.recipeForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  ngOnInit(): void {
    this.recipeForm = this.formBuilder.group({
      medicine: ['', Validators.required],
      quantity: ['', Validators.required],
      instructions: ['', Validators.required]
    });
  }

  Send(){
    console.log(this.idR);
    this.recipeDto.IdR = this.idR;
    this.recipeDto.Medicine = this.recipeForm.value.medicine;
    this.recipeDto.Quantity = this.recipeForm.value.quantity;
    this.recipeDto.Instructions = this.recipeForm.value.instructions;
    console.log(this.recipeDto);
    this.recommendAppointmentService.SendRecipe(this.recipeDto.IdR, this.recipeDto.Medicine, this.recipeDto.Quantity, this.recipeDto.Instructions).subscribe((data: any) =>{

      alert("Recipe is sent!");
    });  
    this.dialogRef.close([]);
    window.location.reload();
  }

}
