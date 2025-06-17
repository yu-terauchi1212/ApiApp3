<template>
  <div>
    <h1>学習履歴一覧</h1>
    <ul>
      <!-- 受け取ったstudiesをループして1件ずつ表示 -->
      <li v-for="study in studies" :key="study.id">
        {{ study.id }} - {{ study.subject }}
      </li>
    </ul>
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
