import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollegeTripPackageComponent } from './college-trip-package.component';

describe('CollegeTripPackageComponent', () => {
  let component: CollegeTripPackageComponent;
  let fixture: ComponentFixture<CollegeTripPackageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CollegeTripPackageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollegeTripPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
