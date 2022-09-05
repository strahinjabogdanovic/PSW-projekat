import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppointmentObserveService } from 'src/app/appointment.service';
import { DrugDto } from './drug.dto';

export interface SelectedMedicine{
  medicine: string;
  quantity: string;
}

@Component({
  selector: 'app-replenish-drugs',
  templateUrl: './replenish-drugs.component.html',
  styleUrls: ['./replenish-drugs.component.css']
})
export class ReplenishDrugsComponent implements OnInit {
  drugDto: DrugDto = {Medicine: "", Quantity: ""};
  selectedMedicine: SelectedMedicine = {medicine: "", quantity: ""};
  medicines: any[]=[];
  recipeForm: FormGroup;
  public medicine: string = "";
  public quantity: string = "";

  constructor(private aos: AppointmentObserveService, private formBuilder: FormBuilder, private router: Router) { 
    this.recipeForm = formBuilder.group({
      title: formBuilder.control('initial value', Validators.required)
    });
  }

  ngOnInit(): void {
    this.recipeForm = this.formBuilder.group({
      medicine: ['', Validators.required],
      quantity: ['', Validators.required],
    });

    this.aos.GetDrugs().subscribe((data: any)=>{
      for(const p of (data as any)){
       this.medicines.push(p);      
     }
   })

  }

  Send(){
    this.drugDto.Medicine = this.recipeForm.value.medicine;
    this.drugDto.Quantity = this.recipeForm.value.quantity;
    console.log(this.drugDto);
    this.aos.Replenish(this.drugDto.Medicine, this.drugDto.Quantity).subscribe(data => {
      alert("Medicine ordered!");
    });
    window.location.reload();
  }

}
