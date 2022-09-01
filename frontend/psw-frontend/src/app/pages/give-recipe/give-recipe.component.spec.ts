import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiveRecipeComponent } from './give-recipe.component';

describe('GiveRecipeComponent', () => {
  let component: GiveRecipeComponent;
  let fixture: ComponentFixture<GiveRecipeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GiveRecipeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GiveRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
