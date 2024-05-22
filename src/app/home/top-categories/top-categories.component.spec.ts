import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopCategoriesComponent } from './top-categories.component';

describe('TopCategoriesComponent', () => {
  let component: TopCategoriesComponent;
  let fixture: ComponentFixture<TopCategoriesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TopCategoriesComponent]
    });
    fixture = TestBed.createComponent(TopCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
