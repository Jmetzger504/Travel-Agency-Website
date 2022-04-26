import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CruiseconfirmationComponent } from './cruiseconfirmation.component';

describe('CruiseconfirmationComponent', () => {
  let component: CruiseconfirmationComponent;
  let fixture: ComponentFixture<CruiseconfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CruiseconfirmationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CruiseconfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
