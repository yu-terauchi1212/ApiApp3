<template>
  <div>
    <h1 class="study-title">学習履歴一覧</h1>
    <table class="study-table">
      <thead>
        <tr>
          <th>ID</th>
          <th>科目</th>
          <th>カテゴリ</th>
          <th>学習時間(h)</th>
          <th>日付</th>
        </tr>
      </thead>
      <tbody>
        <!-- 受け取ったstudiesをループして1件ずつ表示 -->
        <tr v-for="study in studies" :key="study.id">
          <td>{{ study.id }}</td>
          <td>{{ study.subject }}</td>
          <td>{{ study.categories }}</td>
          <td>{{ study.time }}</td>
          <td>{{ study.date }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import axios from 'axios'

// 学習履歴を保持する変数（初期値は空配列）
const studies = ref([])

// ページ表示時にAPIから学習履歴データを取得する処理
onMounted(async () => {
  try {
    const res = await axios.get('http://localhost:5240/ApiApp3 / Study')
    studies.value = res.data // 結果を表示用に代入
  } catch (error) {
    console.error("データ取得エラー:", error)
  }
})
</script>

<style scoped>
.study-title {
  color: #1a5fb4;
  margin-bottom: 20px;
}

.study-table {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
  margin-top: 20px;
  border: 2px solid #1a5fb4;
  border-radius: 0;
  box-shadow: 0 2px 5px rgba(0,0,0,0.1);
}

.study-table th, .study-table td {
  padding: 10px 15px;
  text-align: left;
  border-right: 1px solid #1a5fb4;
  border-bottom: 1px solid #1a5fb4;
}

.study-table th {
  background-color: #1a5fb4;
  color: white;
  font-weight: bold;
  text-transform: uppercase;
  font-size: 0.9em;
  letter-spacing: 0.5px;
}

.study-table tr:nth-child(even) {
  background-color: #fff9c4;
}

.study-table tr:nth-child(odd) {
  background-color: #ffffff;
}

.study-table tr:hover {
  background-color: #ffee58;
  transition: background-color 0.3s ease;
}

.study-table td:last-child,
.study-table th:last-child {
  border-right: none;
}

.study-table tr:last-child td {
  border-bottom: none;
}
</style>
