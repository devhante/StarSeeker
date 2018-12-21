# StarSeeker

### Commit 메시지 규칙

##### 1. Commit 제목

1.  50 자 이내로
2.  제목 끝에 . 금지
3.  제목 앞에 Change, Add, Remove, Refactor, Fix, Hotfix 태그 붙이기
    `좋은 예` [Change] Scan component 를 camera -> barcodescan 을 변경
    `좋은 예` [Fix] Scan component 가 두 번 렌더링 되는 문제 수정
    `나쁜 예` Scan component fix

4.  문장이 아닌, 구문으로 작성
    `좋은 예` [Refactor] Component folder structure
    `좋은 예` [Hotfix] startasync 함수 에러 핸들링 수정
    `나쁜 예` [Hotfix] startasync 함수 에러 핸들링 수정했음

##### 2. Commit 본문

1.  본문을 쓰지 않아도 제목만으로 최대한 Commit 에 대해 이해 되도록 하기
2.  본문을 써야할 경우, 제목과 본문 사이에 공백 한 줄 추가
3.  반드시 문장으로 쓰며, `어떻게` 보다 `무엇을`, `왜`에 맞춰서 작성하기
