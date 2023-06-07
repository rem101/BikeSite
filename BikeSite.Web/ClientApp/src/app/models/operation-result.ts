export interface OperationResult {
  error: string;
  success: boolean;
}

export interface OperationResultWithValue<T> extends OperationResult {
  value: T;
}
