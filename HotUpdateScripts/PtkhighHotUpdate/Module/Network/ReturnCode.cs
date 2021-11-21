using JEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotUpdateScripts.PtkhighHotUpdate.Module.Network
{
    /// <summary>
    /// 返回状态码处理类
    /// </summary>
    public class ReturnCode
    {
        #region Common code
        public const int Error = -2; //非法操作,请重新尝试
        public const int Fail = -1;  //非法操作,请重新尝试
        public const int Success = 1; //操作成功

        #endregion

        #region Account code
        public const int Account_InvalidNumber = 200001;//手机号码格式错误
        public const int Account_InvalidCode = 200002;//验证码无效

        public const int Account_NewDevice = 200402; //新设备登录

        #endregion

        /// <summary>
        /// 从多语言配置文件中读取对应code的描述信息，Localization.csv
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="param"> 某些信息中的参数 如X 分钟 </param>
        /// <returns></returns>
        public static string Desc(int code, string param = null)
        {
            string text = "";
            try
            {
                text = Localization.GetString(code.ToString());
                if (param != null)
                {
                    text = string.Format(text, param);
                }
            }
            catch (Exception e)
            {
                Log.PrintError("请注意code是否在Localization.csv中有对应的配置项," + e.ToString());
            }

            return text;
        }

    }

}


//    public static readonly Dictionary<int, LanguageList> codeDesc = new Dictionary<int, LanguageList> {
//        {-1, new LanguageList( "非法操作,请重新尝试", "Illegal operation, please try again")},
//        {-2, new LanguageList(  "非法操作,请重新尝试", "Illegal operation, please try again")},
//        {1, new LanguageList( "操作成功", "The operation was successful")},
//        {5, new LanguageList( "超过每日最大限额", "Exceeded daily maximum limit")},
//        {400, new LanguageList( "协议错误", "Agreement error")},
//        {403, new LanguageList( "禁止访问", "Access is forbidden")},
//        {503, new LanguageList( "服务器维护，非常抱歉给你带来不便", "Server is currently under maintenance")},
//        {100000, new LanguageList( "操作失败", "Operation failed")},
//        {100001, new LanguageList( "登录验证失败", "Login verification failed")},
//        {100002, new LanguageList( "用户授权失败", "User authorization failed")},
//        {100003, new LanguageList( "创建用户失败", "User creation failed")},
//        {100004, new LanguageList( "其他地方登录或者会话不存在或已过期", "The session does not exist or has expired")},
//        {100005, new LanguageList( "帐号已被禁用", "Account has been disabled")},
//        {100006, new LanguageList( "账户余额不足", "Insufficient account balance")},
//        {100007, new LanguageList( "昵称已存在", "Nickname already exists")},
//        {100008, new LanguageList( "超过数量限制", "Exceeded quantity limit")},
//        {100009, new LanguageList( "请输入呢称(不低于2位汉字或4位字母,数字组合)", "Please enter a nickname (not less than 2 Chinese characters or 4 letters and numbers combination)")},
//        {100010, new LanguageList( "无时间币可领取了", "No time currency can be claimed")},
//        {100011, new LanguageList( "帐号或密码错误", "Username/Number or password is wrong")},
//        {100012, new LanguageList( "密码即将过期,立即修改", "The password is about to expire, modify it now")},
//        {100013, new LanguageList( "原密码和新密码相同", "The original password is the same as the new password")},
//        {100014, new LanguageList( "此类邮箱暂不支持，请更换其他邮箱", "This type of email is not supported. Please change to another email")},
//        {100015, new LanguageList( "此类手机号码暂不支持，请更换其他手机号码", "This type of mobile phone number is not currently supported, please change to another mobile phone number.")},
//        {200001, new LanguageList( "手机号码格式错误", "Invalid mobile phone number")},
//        {200002, new LanguageList( "验证码无效", "The verification code is invalid")},
//        {200003, new LanguageList( "密码错误，请核对密码", "The password is wrong, please check the password")},
//        {200004, new LanguageList( "验证码获取频率过快", "The frequency of obtaining the verification code is too fast")},
//        {200005, new LanguageList( "手机号未注册", "Mobile phone number is not registered")},
//        {200006, new LanguageList( "数字货币账号注册失败", "Digital currency account registration failed")},
//        {200007, new LanguageList( "数字货币账号登陆失败", "Digital currency account login failed")},
//        {200008, new LanguageList( "设置pin失败", "Setting pin failed")},
//        {200009, new LanguageList( "数字货币余额读取失败，请稍后再试", "The digital currency balance reading failed, please try again later")}, // 参数错误-查询用户资产失败
//        {200010, new LanguageList( "查询失败", "Query failed")},
//        {200011, new LanguageList( "余额变动错误", "Balance change error/Asset operation parameter error")}, // 资产操作参数错误
//        {200012, new LanguageList( "余额不足", "Insufficient balance")}, // 资产操作失败 - 资产不足
//        {200013, new LanguageList( "数字货币账号注册或登陆失败", "Digital currency account registration or login failed.digital goodsCoin account registration or login parameters are wrong")}, // 数字货币账号注册或登陆参数错误
//        {200014, new LanguageList( "通道维护中，请稍后再试", "Channel under maintenance, please try again later")},
//        {200015, new LanguageList( "兑换申请提交成功待审核", "Application submitted successfully and is pending review")},// 时间币兑换申请提交成功待审核
//        {200016, new LanguageList( "请求数据错误", "Request data error")},// 请求列表参数错误
//        {200017, new LanguageList( "邮箱格式错误", "Invalid Email format")},
//        {200018, new LanguageList( "手机号码已被绑定", "Mobile phone number has been bound")},
//        {200019, new LanguageList( "邮箱已被绑定", "Email has been bound")},
//        {200020, new LanguageList( "绑定手机或邮箱失败", "Failed to bind mobile phone or email")},
//        {200021, new LanguageList( "修改密码失败", "Failed to modify password")},
//        {200022, new LanguageList( "时间币商城 未开启", "Timecoin Mall is not open")},
//        {200023, new LanguageList( "账号格式错误", "Account format error")},
//        {200024, new LanguageList( "数字货币商城 未开启", "The digital currency store is not open")},
//        {200030, new LanguageList( "该邮箱未注册", "Email is not registered")},
//        {200100, new LanguageList( "通道维护中，请稍后再试", "Channel under maintenance, please try again later")}, // 兑换 - 参数错误
//        {200101, new LanguageList( "通道维护中，请稍后再试", "Channel under maintenance, please try again later")}, // 兑换 - 时间币操作失败
//        {200102, new LanguageList( "通道维护中，请稍后再试", "Channel under maintenance, please try again later")}, // 兑换 - 数字货币操作失败
//        {200103, new LanguageList( "挂单失败", "Pending order failed")}, // 兑换 - 挂单失败
//        {200104, new LanguageList( "查询汇率失败，请稍后再试", "Exchange rate query failed, please try again later")}, // 兑换 - 查询汇率失败
//        {200105, new LanguageList( "挂单失败", "Pending order failed")}, // 兑换 - 挂单失败 Exchange-pending order failed
//        {200106, new LanguageList( "挂单失败", "Pending order failed")}, // 兑换 - 挂单参数错误 Exchange-pending order parameter error
//        {200107, new LanguageList( "挂单失败", "Pending order failed")}, // 兑换 - 挂单数据错误 Exchange-pending order data error
//        {200108, new LanguageList( "您输入的数量超出限制", "The amount you entered exceeds the limit")}, // 获取兑换限制失败(最大最小值
//        {200109, new LanguageList( "操作失败", "Operation failed")}, // 获取提现是否需要审核错误
//        {200110, new LanguageList( "余额不足", "Insufficient balance")}, // 挂单失败 - 余额不足
//        {200111, new LanguageList( "请先前往设置PIN", "Please set PIN first")}, // 查询失败 - 请先前往设置PIN
//        {200112, new LanguageList( "不能与原PIN码相同", "PIN cannot be the same as previous PIN")}, // 设置失败 - 不能与原PIN相同
//        {200113, new LanguageList( "兑换失败", "Exchange failed")},
//        {200114, new LanguageList( "由于盘口数量不足，已成功兑换XXX时间币", "Due to insufficient market volume, the XXX time currency has been successfully exchanged")},
//        {200200, new LanguageList( "赠送失败", "Transfer failed")}, // 时间币赠送 - 参数错误
//        {200201, new LanguageList( "密码验证失败", "Password Verification Failed")}, // 时间币赠送 - 赠送人密码验证失败
//        {200202, new LanguageList( "赠送失败", "Transfer failed")}, // 时间币赠送 - 扣除赠送人时间币错误
//        {200203, new LanguageList( "赠送失败，请联系工作人员", "Transfer failed")}, // 时间币赠送 - 回滚除赠送人时间币错误
//        {200204, new LanguageList( "赠送失败，请联系工作人员", "Transfer failed")}, // 时间币赠送 - 增加接收人时间币错误
//        {200205, new LanguageList( "低于最小额度", "Amount is below the required minimum")}, // 游戏币赠送 - 低于转币最小值
//        {200206, new LanguageList( "超出最大额度", "Maximum limit exceeded")}, // 游戏币赠送 - 超出最大值
//        {200207, new LanguageList( "您今日累计转账数额已经超过限制", "You have reached your daily transfer amount limit")},
//        {200300, new LanguageList( "兑换参数错误", "Exchange parameter error")}, // 提交兑换参数错误，type验证不通过
//        {200301, new LanguageList( "兑换失败", "Exchange failed")}, // VGPay修改用户资产失败
//        {200302, new LanguageList( "充币地址读取失败，请稍后再试", "The deposit address failed to read, please try again later")}, // 获取充值地址失败
//        {200303, new LanguageList( "请求失败", "Request failed")}, // 获取提现配置失败
//        {200304, new LanguageList( "通道维护中，请稍后再试", "The channel is under maintenance, please try again later")}, // 提现申请提交失败
//        {200305, new LanguageList( "读取记录失败，请稍后再试", "Failed to read the record, please try again later")}, // 获取记录失败
//        {200306, new LanguageList( "自动转换时间币失败，请使用手动兑换","Automatic time currency conversion failed, please use manual exchange instead")},
//        {200400, new LanguageList( "该账号已注册", "Account has been registered")},
//        {200401, new LanguageList( "密码无效", "Invalid password")},
//        {200402, new LanguageList( "新设备登录", "New device log in")},
//        {300001, new LanguageList( "商品不存在", "The item does not exist")},
//        {300002, new LanguageList( "创建订单失败", "Order creation failed")},
//        {300003, new LanguageList( "支付校验失败", "Payment verification failed")},
//        {300004, new LanguageList( "订单不存在", "Order does not exist")},
//        {300005, new LanguageList( "订单更新失败", "Order update failed")},
//        {300006, new LanguageList( "参数错误", "Parameter error")},
//        {300007, new LanguageList( "已下架", "Item does not exists")},
//        {300008, new LanguageList( "余额不足", "Time currency balance is insufficient")},
//        {300009, new LanguageList( "练习币购买失败", "Purchase practice coin failed")},
//        // 支付返回值
//        {400001, new LanguageList( "没有可用的支付方式", "No payment method available")}, // 获取支付方式失败，或者没有可用的支付方式 status = 1
//        {400002, new LanguageList( "获取支付方式失败", "Failed to obtain payment method")}, // 参数错误pay_id，获取支付方式失败
//        {400003, new LanguageList( "发送支付请求失败", "Sending payment request failed")}, // curl失败
//        {400004, new LanguageList( "支付失败", "Payment failed")}, // ftpay返回失败
//        {400005, new LanguageList( "订单信息创建失败", "Order information creation failed")}, // 插入数据库失败，订单信息创建失败
//        {400006, new LanguageList( "提现发起失败，请核对信息后重试", "Withdrawal initiation failed, please check the information and try again")}, // 参数不正确
//        {400007, new LanguageList( "生成提现订单失败", "Generate withdrawal order failed")}, // 插入数据库失败
//        {400008, new LanguageList( "暂不支持提现到该银行", "Withdrawal to this bank is not currently supported")}, // status = 2
//        {400009, new LanguageList( "请勿重复提交", "Do not submit repeatedly")}, // 订单状态不为1
//        {400010, new LanguageList( "通道维护中，请等待", "Channel under maintenance, please wait")}, // 没有可用的代付渠道
//        {400011, new LanguageList( "通道维护中，请等待", "Channel under maintenance, please wait")}, // 通道余额不足
//        {400012, new LanguageList( "余额不足,提现发起失败", "Insufficient balance, withdrawal initiation failed")}, // 通道余额不足
//        {400013, new LanguageList( "支付通道维护中", "Payment channel is under maintenance")}, // 支付通道维护中
//        {400014, new LanguageList( "支付通道不在可用时间", "Payment channel is not available at the time")}, // 支付通道不在可用时间
//        {400016, new LanguageList( "提交失败", "Submission failed")}, // 限制支付名单
//        {400018, new LanguageList( "支付禁用中,请稍后再试或联系客服", "Payment disabled,Please try again later or contact customer service")},
//        {400019, new LanguageList( "操作过于频繁, 请联系客服", "The operation is too frequent, please contact customer service")},
//        {400100, new LanguageList( "没有二级密码，请先前往设置二级密码", "There is no secondary password, please go to set the secondary password first")}, // PIN验证未通过
//        {400101, new LanguageList( "您的二级密码码处于锁定中，请稍后再试", "PIN Locked, Try again later")}, // PIN验证未通过
//        {400102, new LanguageList( "错误次数过多，已被锁定 X 分钟", "Too many errors,Has been locked for X minutes")}, // PIN验证未通过
//        {400103, new LanguageList( "二级密码验证未通过, 剩余次数: X", "PIN Error, remaining times: ")}, // PIN验证未通过
//        {400105, new LanguageList( "您的验证码处于锁定中，请稍后再试", "Your verification code is locked, please wait and try again")},
//        {400106, new LanguageList( "错误次数过多，已被锁定 X 分钟", "Too many errors, alreadyLocked for X minutes")},
//        {400107, new LanguageList( "验证码验证未通过, 剩余次数: X", "Verification code verification failed, remaining times: ")},

//  //Others
//        {20412, new LanguageList( "IP限制", "The area of ​​your mobile phone number does not support access to poker time")},
//        {20413, new LanguageList( "IP限制", "IP restricted")},
//        {1001, new LanguageList( "俱乐部名称已存在", "'Club name already exists")},
//        {1002, new LanguageList( "俱乐部创建失败，请稍后重试", "Club creation failed, please try again later")},
//        {1003, new LanguageList( "俱乐部创建太频繁", "The club is created too frequently")},
//        {1011, new LanguageList( "已经加入该俱乐部", "has joined the club")},
//        {1012, new LanguageList( "俱乐部人数已满", "The club is full")},
//        {1013, new LanguageList( "加入俱乐部失败，请稍后重试", "Failed to join the club, please try again later")},
//        {1021, new LanguageList( "修改俱乐部头像失败，请稍后重试", "Failed to modify the club profile picture, please try again later")},
//        {1022, new LanguageList( "修改俱乐部名称失败，请稍后重试", "Failed to modify the club name, please try again later")},
//        {1023, new LanguageList( "修改俱乐部介绍失败，请稍后重试", "Failed to modify the club introduction, please try again later")},
//        {1024, new LanguageList( "俱乐部头像不能为空", "Club picture cannot be empty")},
//        {1031, new LanguageList( "转入到俱乐部余额失败，请稍后重试", "Failed to transfer to the club balance, please try again later")},
//        {1032, new LanguageList( "余额不足", "Time currency balance is insufficient")},
//        {1033, new LanguageList( "转入到俱乐部余额出错，请稍后重试", "An error occurred when transferring to the club balance, please try again later")},
//        {1034, new LanguageList( "余额不足", "Poker currency balance is insufficient")},
//        {1041, new LanguageList( "俱乐部基金余额不足", "The club fund balance is insufficient")},
//        {1042, new LanguageList( "俱乐部基金余额提现出错，请稍后重试", "Club fund balance withdrawal error, please try again later")},
//        {1043, new LanguageList( "超过每日最大限额", "Exceeded daily maximum limit")},
//        {1044, new LanguageList( "俱乐部基金余额提现失败，请稍后重试", "The club fund balance withdrawal failed, please try again later")},
//        {1045, new LanguageList( "俱乐部基金提取受限，低于{0}(含)的部分不可提取", "Club fund withdrawal is restricted, and the part below {0} (inclusive) cannot be withdrawn")},
//        {1061, new LanguageList( "修改备注失败，请稍后重试", "Failed to modify the remark, please try again later")},
//        {1081, new LanguageList( "管理员设置出错，请稍后重试", "Administrator setting error, please try again later")},
//        {1091, new LanguageList( "免费提现额度返利设置失败，请稍后重试", "The free withdrawal limit rebate setting failed, please try again later")},
//        {1101, new LanguageList( "俱乐部开关设置失败，请稍后重试", "Club switch setting failed, please try again later")},
//        {1111, new LanguageList( "俱乐部基金尚有余额，无法解散。请及时前往俱乐部基金处理", "The club fund still has a balance and cannot be dissolved. Please go to the club in timeDepartment of Fund Processing")},
//        {1112, new LanguageList( "解散俱乐部失败，请稍后重试", "Failed to dissolve the club, please try again later")},
//        {1113, new LanguageList( "俱乐部基金不为0，无法解散俱乐部", "The club fund is not 0, the club cannot be dissolved")},
//        {1114, new LanguageList( "俱乐部有进行中的牌局，无法解散俱乐部", "The club has cards in progress and the club cannot be disbanded")},
//        {1115, new LanguageList( "已加入联盟无法解散俱乐部, 请退出联盟后重试", "You have joined the league and cannot disband the club, please exit the league and restart test!")},
//        {1121, new LanguageList( "用户信任额度不为 0", "User credit limit is not 0")},
//        {1122, new LanguageList( "退出俱乐部失败，请稍后重试", "Failed to exit the club, please try again later")},
//        {1123, new LanguageList( "俱乐部还款失败, 请稍后重试", "The club repayment failed, please try again later")},
//        {1124, new LanguageList( "俱乐部还款出错, 请稍后重试", "Club repayment error, please try again later")},
//        {1125, new LanguageList( "俱乐部没有欠款", "The club has no debts")},
//        {126, new LanguageList( "俱乐部全部还款失败, 请稍后重试", "All the club repayment failed, please try again later")},
//        {1127, new LanguageList( "俱乐部尚有未还欠款, 请处理后重试", "The club still has outstanding debts, please deal with it and try again")},
//        {1131, new LanguageList( "俱乐部不存在", "The club does not exist")},
//        {1151, new LanguageList( "设置俱乐部保险赔付方式失败，请稍后重试", "Failed to set club insurance payment method, please try again later")},
//        {1152, new LanguageList( "设置俱乐部保险赔付限制失败，请稍后重试", "Failed to set club insurance compensation limit, please try again later")},
//        {1161, new LanguageList( "没有要处理的消息", "No message to be processed")},
//        {1162, new LanguageList( "处理用户加入失败，请稍后重试", "Failed to process user join, please try again later")},
//        {3001, new LanguageList( "联盟不存在", "Alliance does not exist")},
//         {3002, new LanguageList( "已经加入联盟", "Already joined the alliance")},
//         {3003, new LanguageList( "联盟的俱乐部数量已满", "The number of league clubs is full")},
//         {3004, new LanguageList( "加入联盟失败，请稍后重试", "Failed to join the alliance, please try again later")},
//         {3005, new LanguageList( "修改联盟介绍失败，请稍后重试’", "Failed to modify the alliance introduction, please try again later")},
//         {3006, new LanguageList( "添加管理员失败，请稍后重试", "Failed to add administrator, please try again later")},
//         {3007, new LanguageList( "删除管理员失败，请稍后重试", "Failed to delete the administrator, please try again later")},
//         {3008, new LanguageList( "处理俱乐部加入失败，请稍后重试", "Failed to process club joining, please try again later")},
//         {009, new LanguageList( "没有要处理的消息", "No message to be processed")},
//         {3010, new LanguageList( "删除俱乐部失败，请稍后重试", "Failed to delete the club, please try again later")},
//         {3011, new LanguageList( "退出联盟失败，请稍后重试", "Failed to exit the alliance, please try again later")},
//         {3012, new LanguageList( "转入到联盟基金余额失败，请稍后重试", "Failed to transfer to the alliance fund balance, please try again later")},
//         {3013, new LanguageList( "余额不足", "Time currency balance is insufficient")},
//         {3014, new LanguageList( "转入到联盟基金余额出错，请稍后重试", "An error occurred when transferring to the alliance fund balance, please try again later")},
//         {3015, new LanguageList( "联盟基金余额不足", "The alliance fund balance is insufficient")},
//         {3016, new LanguageList( "联盟基金余额提现出错，请稍后重试", "Affiliate fund balance withdrawal error, please try again later")},
//         {3017, new LanguageList( "超过每日最大限额", "Exceeded the daily maximum limit")},
//         {3018, new LanguageList( "联盟基金余额提现失败，请稍后重试", "Alliance fund balance withdrawal failed, please try again later'")},
//         {3019, new LanguageList( "用户已经是联盟的管理员", "The user is already an administrator of the alliance")},
//         {3020, new LanguageList( "加入的联盟数量已达上限", "The number of alliances joined has reached the upper limit")},
//         {3021, new LanguageList( "加入失败，请联系联盟主", "Join failed, please contact the alliance owner")},
//    };


//}


