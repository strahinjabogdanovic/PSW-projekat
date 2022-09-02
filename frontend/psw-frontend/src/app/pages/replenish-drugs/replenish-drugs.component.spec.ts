import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReplenishDrugsComponent } from './replenish-drugs.component';

describe('ReplenishDrugsComponent', () => {
  let component: ReplenishDrugsComponent;
  let fixture: ComponentFixture<ReplenishDrugsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReplenishDrugsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReplenishDrugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
