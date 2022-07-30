import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentObserveComponent } from './appointment-observe.component';

describe('AppointmentObserveComponent', () => {
  let component: AppointmentObserveComponent;
  let fixture: ComponentFixture<AppointmentObserveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppointmentObserveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentObserveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
