import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherDetailsComponent } from './publisher-details.component';

describe('PublisherDetailsComponent', () => {
  let component: PublisherDetailsComponent;
  let fixture: ComponentFixture<PublisherDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PublisherDetailsComponent]
    });
    fixture = TestBed.createComponent(PublisherDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
