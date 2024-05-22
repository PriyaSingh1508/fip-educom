import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriesBadgeComponent } from './categories-badge.component';

describe('CategoriesBadgeComponent', () => {
  let component: CategoriesBadgeComponent;
  let fixture: ComponentFixture<CategoriesBadgeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CategoriesBadgeComponent]
    });
    fixture = TestBed.createComponent(CategoriesBadgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
