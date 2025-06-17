<template>
  <div>
    <h1 class="study-title">学習履歴入力</h1>
    
    <div class="form-container">
      <div class="form-group">
        <label for="subject">科目</label>
        <input id="subject" v-model="subject" placeholder="科目名を入力してください" />
      </div>
      
      <div class="form-group">
        <label for="categories">カテゴリ</label>
        <input id="categories" v-model="categories" placeholder="カテゴリを入力してください" />
      </div>
      
      <div class="form-group">
        <label for="time">学習時間(h)</label>
        <input id="time" v-model="time" placeholder="学習時間を入力してください" type="number" step="0.5" />
      </div>
      
      <div class="form-group">
        <label for="date">学習日</label>
        <input id="date" v-model="date" placeholder="YYYY-MM-DD" type="date" />
      </div>
      
      <button class="submit-button" @click="submit">送信する</button>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'

const subject = ref('')
const categories = ref('')
const time = ref('')
const date = ref('')

const submit = async () => {
  const payload = {
    subject: subject.value,
    categories: categories.value,
    time: time.value,
    date: date.value
  }

  try {
    await axios.post('http://localhost:5240/ApiApp3 / Study', payload)
    alert('登録完了')
    subject.value = ''
    categories.value = ''
    time.value = ''
    date.value = ''
  } catch (e) {
    console.error('登録エラー', e)
  }
}
</script>

<style scoped>
.study-title {
  color: #1a5fb4;
  margin-bottom: 20px;
}

.form-container {
  width: 500px;
  padding: 20px;
  background-color: #ffffff;
  border: 2px solid #1a5fb4;
  box-shadow: 0 2px 5px rgba(0,0,0,0.1);
  margin-top: 20px;
}

.form-group {
  margin-bottom: 15px;
  display: flex;
  flex-direction: column;
}

label {
  color: #1a5fb4;
  font-weight: bold;
  margin-bottom: 5px;
  font-size: 0.9em;
  text-transform: uppercase;
  letter-spacing: 0.5px;
}

input {
  padding: 10px;
  border: 1px solid #1a5fb4;
  background-color: #fff9c4;
  font-size: 1rem;
  transition: all 0.3s ease;
}

input:focus {
  outline: none;
  background-color: #ffffff;
  border-color: #ffee58;
  box-shadow: 0 0 3px #ffee58;
}

.submit-button {
  background-color: #1a5fb4;
  color: white;
  border: none;
  padding: 12px 20px;
  cursor: pointer;
  font-weight: bold;
  text-transform: uppercase;
  letter-spacing: 0.5px;
  margin-top: 10px;
  transition: background-color 0.3s ease;
  align-self: flex-start;
  font-size: 1rem;
}

.submit-button:hover {
  background-color: #154a8c;
}

.submit-button:active {
  background-color: #0e325e;
}
</style>