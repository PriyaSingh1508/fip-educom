import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeTutorialsLibraryComponent } from './home-tutorials-library.component';

describe('HomeTutorialsLibraryComponent', () => {
  let component: HomeTutorialsLibraryComponent;
  let fixture: ComponentFixture<HomeTutorialsLibraryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HomeTutorialsLibraryComponent]
    });
    fixture = TestBed.createComponent(HomeTutorialsLibraryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
