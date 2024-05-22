import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrarypageComponent } from './librarypage.component';

describe('LibrarypageComponent', () => {
  let component: LibrarypageComponent;
  let fixture: ComponentFixture<LibrarypageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LibrarypageComponent]
    });
    fixture = TestBed.createComponent(LibrarypageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
