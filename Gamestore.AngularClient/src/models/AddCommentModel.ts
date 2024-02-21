export interface AddCommentModel {
  gameAlias: string;
  authorName: string;
  body: string;
  asReplyTo?: number;
  asQuoteTo?: number;
}
