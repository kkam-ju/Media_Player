using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMain
{
    public static class UserSession
    {
        // 로그인 여부
        public static bool IsLoggedIn { get; private set; }

        public static int UserId { get; private set; }
        // 사용자 ID
        public static string Username { get; private set; }

        // 사용자 닉네임
        public static string Nickname { get; private set; }

        //관리자 닉네임
        public static bool Manager { get; private set; }

        //프리미엄
        public static bool IsPremium { get; set; }

        /// <summary>
        /// 로그인 성공 시 호출하여 사용자 정보를 저장합니다.
        /// </summary>
        /// <param name="username">사용자 ID</param>
        /// <param name="nickname">사용자 닉네임</param>
        public static void Login(int userid, string username, string nickname, bool manager, bool premium)
        {
            IsLoggedIn = true;
            UserId = userid;
            Username = username;
            Nickname = nickname;
            Manager = manager;
            IsPremium = premium;
        }

        /// <summary>
        /// 로그아웃 시 호출하여 모든 세션 정보를 초기화합니다.
        /// </summary>
        public static void Logout()
        {
            IsLoggedIn = false;
            UserId = 0; // ◀◀◀ 추가된 부분
            Username = null;
            Nickname = null;
            Manager = false;
            IsPremium = false;
        }
    }
}