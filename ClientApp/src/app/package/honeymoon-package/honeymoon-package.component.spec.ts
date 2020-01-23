import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HoneymoonPackageComponent } from './honeymoon-package.component';

describe('HoneymoonPackageComponent', () => {
  let component: HoneymoonPackageComponent;
  let fixture: ComponentFixture<HoneymoonPackageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HoneymoonPackageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HoneymoonPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
