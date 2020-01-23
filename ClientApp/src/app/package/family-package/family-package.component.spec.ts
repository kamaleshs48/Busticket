import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyPackageComponent } from './family-package.component';

describe('FamilyPackageComponent', () => {
  let component: FamilyPackageComponent;
  let fixture: ComponentFixture<FamilyPackageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamilyPackageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamilyPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
