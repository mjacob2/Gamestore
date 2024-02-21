import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentsListingComponent } from './comments-listing.component';

describe('CommentsListingComponent', () => {
  let component: CommentsListingComponent;
  let fixture: ComponentFixture<CommentsListingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CommentsListingComponent]
    });
    fixture = TestBed.createComponent(CommentsListingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
