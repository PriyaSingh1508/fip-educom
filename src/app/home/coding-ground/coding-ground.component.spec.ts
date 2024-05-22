import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CodingGroundComponent } from './coding-ground.component';

describe('CodingGroundComponent', () => {
  let component: CodingGroundComponent;
  let fixture: ComponentFixture<CodingGroundComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CodingGroundComponent]
    });
    fixture = TestBed.createComponent(CodingGroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
