import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialistAppointmentComponent } from './specialist-appointment.component';

describe('SpecialistAppointmentComponent', () => {
  let component: SpecialistAppointmentComponent;
  let fixture: ComponentFixture<SpecialistAppointmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpecialistAppointmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialistAppointmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
