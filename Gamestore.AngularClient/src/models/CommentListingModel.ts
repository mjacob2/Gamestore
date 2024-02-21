import { Data } from "@angular/router";

export interface CommentListingModel {
  id: number;
  authorName: string;
  body: string;
  canBeDeletedByUser: boolean;
  asReplyTo: number;
  asQuoteTo: number;
  commentType: CommentType;
  banUntil: Date;
}

export enum CommentType {
  reply,
  quote,
}
