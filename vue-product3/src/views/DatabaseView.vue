<template> 
<div class="database-container">
<h1> 学習履歴検索 </h1>
<h3>科目を入力し、科目ごとの学習履歴を表示します。</h3>
<input type="text" v-model="subject" placeholder="科目名を入力" />
<button @click="search(doc)">検索</button>
</div>
<div class ="study-list">
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
const db = ref([])

const subject = ref('')

const search = async(doc) => {
    try {
        const res = await axios.get('http://localhost:5240/ApiApp3 / Study')
       
            db.value = res.data // 結果を表示用に代入
         if(db.value.subject === doc){
            studies.value = db.value.filter(study => study.subject === subject.value);

         } else {
            alert("該当する科目がありません。")
        }
    } catch (error) {
        console.error("データ取得エラー:", error)
    }
};

</script>