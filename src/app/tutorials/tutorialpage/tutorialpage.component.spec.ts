import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TutorialpageComponent } from './tutorialpage.component';

describe('TutorialpageComponent', () => {
  let component: TutorialpageComponent;
  let fixture: ComponentFixture<TutorialpageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TutorialpageComponent]
    });
    fixture = TestBed.createComponent(TutorialpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
